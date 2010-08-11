﻿using System;
using System.Collections.Generic;

namespace Jurassic.Compiler
{

    /// <summary>
    /// Represents a javascript for-in statement.
    /// </summary>
    internal class ForInStatement : Statement
    {
        /// <summary>
        /// Creates a new ForInStatement instance.
        /// </summary>
        /// <param name="labels"> The labels that are associated with this statement. </param>
        public ForInStatement(IList<string> labels)
            : base(labels)
        {
        }

        /// <summary>
        /// Gets or sets a reference to mutate on each iteration of the loop.
        /// </summary>
        public IReferenceExpression Variable
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the portion of source code associated with the variable.
        /// </summary>
        public SourceCodeSpan VariableDebugInfo
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets an expression that evaluates to the object to enumerate.
        /// </summary>
        public Expression TargetObject
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the portion of source code associated with the target object.
        /// </summary>
        public SourceCodeSpan TargetObjectDebugInfo
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the loop body.
        /// </summary>
        public Statement Body
        {
            get;
            set;
        }

        /// <summary>
        /// Generates CIL for the statement.
        /// </summary>
        /// <param name="generator"> The generator to output the CIL to. </param>
        /// <param name="optimizationInfo"> Information about any optimizations that should be performed. </param>
        protected override void GenerateCodeCore(ILGenerator generator, OptimizationInfo optimizationInfo)
        {
            // Construct a loop expression.
            // var enumerator = TypeUtilities.EnumeratePropertyNames(rhs).GetEnumerator();
            // while (true) {
            //   continue-target:
            //   if (enumerator.MoveNext() == false)
            //     goto break-target;
            //   lhs = enumerator.Current;
            //
            //   <body statements>
            // }
            // break-target:

            // Emit debugging information.
            if (optimizationInfo.DebugDocument != null)
                generator.MarkSequencePoint(optimizationInfo.DebugDocument, this.TargetObjectDebugInfo);

            // Emit the arguments for EnumeratePropertyNames().
            EmitHelpers.LoadScriptEngine(generator);
            this.TargetObject.GenerateCode(generator, optimizationInfo);
            EmitConversion.ToAny(generator, this.TargetObject.ResultType);

            // Call EnumeratePropertyNames()
            generator.Call(ReflectionHelpers.TypeUtilities_EnumeratePropertyNames2);

            // Call GetEnumerator()
            generator.Call(ReflectionHelpers.IEnumerable_GetEnumerator);

            // Store the enumerator in a temporary variable.
            var enumerator = generator.CreateTemporaryVariable(typeof(object));
            generator.StoreVariable(enumerator);

            var breakTarget = generator.CreateLabel();
            var continueTarget = generator.DefineLabelPosition();

            // Emit debugging information.
            if (optimizationInfo.DebugDocument != null)
                generator.MarkSequencePoint(optimizationInfo.DebugDocument, this.VariableDebugInfo);

            //   if (enumerator.MoveNext() == false)
            //     goto break-target;
            generator.LoadVariable(enumerator);
            generator.Call(ReflectionHelpers.IEnumerator_MoveNext);
            generator.BranchIfFalse(breakTarget);

            // lhs = enumerator.Current;
            generator.LoadVariable(enumerator);
            generator.Call(ReflectionHelpers.IEnumerator_Current);
            this.Variable.GenerateSet(generator, optimizationInfo, PrimitiveType.String, false);

            // Emit the body statement(s).
            optimizationInfo.PushBreakOrContinueInfo(this.Labels, breakTarget, continueTarget, false);
            this.Body.GenerateCode(generator, optimizationInfo);
            optimizationInfo.PopBreakOrContinueInfo();

            generator.Branch(continueTarget);
            generator.DefineLabelPosition(breakTarget);
        }

        

        /// <summary>
        /// Converts the statement to a string.
        /// </summary>
        /// <param name="indentLevel"> The number of tabs to include before the statement. </param>
        /// <returns> A string representing this statement. </returns>
        public override string ToString(int indentLevel)
        {
            var result = new System.Text.StringBuilder();
            result.Append(new string('\t', indentLevel));
            result.AppendFormat("for ({0} in {1})",
                this.Variable.ToString(),
                this.TargetObject.ToString());
            result.AppendLine();
            result.Append(this.Body.ToString(indentLevel + 1));
            return result.ToString();
        }
    }

}