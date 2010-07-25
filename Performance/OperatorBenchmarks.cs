﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Performance
{

    /// <summary>
    /// Benchmarks the javascript operators.
    /// </summary>
    [TestClass]
    public class OperatorBenchmarks
    {

        [TestMethod]
        public void BitwiseAnd()
        {
            TestUtils.Benchmark(@"
                function f() {
                    var x = 0;
                    for (var i = 0; i < 100000; i++)
                        x = x & i
                }
                f()
                ", 149.2);
        }

        [TestMethod]
        public void BitwiseOr()
        {
            TestUtils.Benchmark(@"
                function f() {
                    var x = 0;
                    for (var i = 0; i < 100000; i++)
                        x = x | i
                }
                f();
                ", 146.8);
        }

        [TestMethod]
        public void BitwiseXor()
        {
            TestUtils.Benchmark(@"
                function f() {
                    var x = 0;
                    for (var i = 0; i < 100000; i++)
                        x = x ^ i
                }
                f();
                ", 138.9);
        }

        [TestMethod]
        public void Add()
        {
            TestUtils.Benchmark(@"
                function f() {
                    var x = 0;
                    for (var i = 0; i < 100000; i++)
                        x = x + i
                }
                f();
                ", 121.0);
        }

        [TestMethod]
        public void Subtract()
        {
            TestUtils.Benchmark(@"
                function f() {
                    var x = 0;
                    for (var i = 0; i < 100000; i++)
                        x = x - i
                }
                f();
                ", 157.2);
        }

        [TestMethod]
        public void Multiply()
        {
            TestUtils.Benchmark(@"
                function f() {
                    var x = 0;
                    for (var i = 0; i < 100000; i++)
                        x = x * i
                }
                f();
                ", 168.9);
        }

        [TestMethod]
        public void Divide()
        {
            TestUtils.Benchmark(@"
                function f() {
                    var x = 0;
                    for (var i = 1; i < 100000; i++)
                        x = x / i
                }
                f();
                ", 171.8);
        }

        [TestMethod]
        public void Modulo()
        {
            TestUtils.Benchmark(@"
                function f() {
                    var x = 0;
                    for (var i = 1; i < 100000; i++)
                        x = x % i
                }
                f();
                ", 107.4);
        }

        [TestMethod]
        public void LeftShift()
        {
            TestUtils.Benchmark(@"
                function f() {
                    var x = 0;
                    for (var i = 0; i < 100000; i++)
                        x = x << i
                }
                f();
                ", 146.1);
        }

        [TestMethod]
        public void SignedRightShift()
        {
            TestUtils.Benchmark(@"
                function f() {
                    var x = 0;
                    for (var i = 0; i < 100000; i++)
                        x = x >> i
                }
                f();
                ", 143.9);
        }

        [TestMethod]
        public void UnsignedRightShift()
        {
            TestUtils.Benchmark(@"
                function f() {
                    var x = 0;
                    for (var i = 0; i < 100000; i++)
                        x = x >>> i
                }
                f();
                ", 127.5);
        }

        [TestMethod]
        public void LessThan()
        {
            TestUtils.Benchmark(@"
                function f() {
                    var x = 0;
                    for (var i = 0; i < 100000; i++)
                        x = x < i
                }
                f();
                ", 111.7);
        }

        [TestMethod]
        public void LessThanOrEquals()
        {
            TestUtils.Benchmark(@"
                function f() {
                    var x = 0;
                    for (var i = 0; i < 100000; i++)
                        x = x <= i
                }
                f();
                ", 110.7);
        }

        [TestMethod]
        public void GreaterThan()
        {
            TestUtils.Benchmark(@"
                function f() {
                    var x = 0;
                    for (var i = 0; i < 100000; i++)
                        x = x > i
                }
                f();
                ", 112.1);
        }

        [TestMethod]
        public void GreaterThanOrEquals()
        {
            TestUtils.Benchmark(@"
                function f() {
                    var x = 0;
                    for (var i = 0; i < 100000; i++)
                        x = x >= i
                }
                f();
                ", 110.9);
        }

        [TestMethod]
        public void Equals()
        {
            TestUtils.Benchmark(@"
                function f() {
                    var x = 0;
                    for (var i = 0; i < 100000; i++)
                        x = x == i
                }
                f();
                ", 110.2);
        }

        [TestMethod]
        public void StrictEquals()
        {
            TestUtils.Benchmark(@"
                function f() {
                    var x = 0;
                    for (var i = 0; i < 100000; i++)
                        x = x === i
                }
                f();
                ", 135.4);
        }

        [TestMethod]
        public void NotEquals()
        {
            TestUtils.Benchmark(@"
                function f() {
                    var x = 0;
                    for (var i = 0; i < 100000; i++)
                        x = x != i
                }
                f();
                ", 118.7);
        }

        [TestMethod]
        public void StrictNotEquals()
        {
            TestUtils.Benchmark(@"
                function f() {
                    var x = 0;
                    for (var i = 0; i < 100000; i++)
                        x = x !== i
                }
                f();
                ", 137.4);
        }

        [TestMethod]
        public void LogicalAnd()
        {
            TestUtils.Benchmark(@"
                function f() {
                    var x = 0;
                    for (var i = 0; i < 100000; i++)
                        x = x && i
                }
                f();
                ", 202.2);
        }

        [TestMethod]
        public void LogicalOr()
        {
            TestUtils.Benchmark(@"
                function f() {
                    var x = 0;
                    for (var i = 0; i < 100000; i++)
                        x = x || i
                }
                f();
                ", 177.2);
        }

        [TestMethod]
        public void FunctionCall()
        {
            TestUtils.Benchmark(@"
                function f(a, b, c) {
                }
                for (var i = 0; i < 10000; i++)
                    f(1, 2, 3)
                ", 80.9);
        }

        [TestMethod]
        public void Arguments()
        {
            TestUtils.Benchmark(@"
                function f(a, b, c) {
                    return arguments[0] - arguments[1] - arguments[2];
                }
                for (var i = 0; i < 10000; i++)
                    f(1, 2, 3)
                ", 0.9);
        }

        [TestMethod]
        public void LocalVariableAccess()
        {
            TestUtils.Benchmark(@"
                function f() {
                    var a = 0, b = 1, c = 2, d = 3, e = 4, f = 5, g = 6;
                    for (var i = 0; i < 100000; i ++)
                    {
                        a = b;
                        b = c;
                        c = d;
                        d = e;
                        e = f;
                        f = g;
                        g = a;
                    }
                }
                f()
                ", 106.2);
        }

        [TestMethod]
        public void GlobalVariableAccess()
        {
            TestUtils.Benchmark(@"
                var a = 0, b = 1, c = 2, d = 3, e = 4, f = 5, g = 6;
                for (var i = 0; i < 100000; i ++)
                {
                    a = b;
                    b = c;
                    c = d;
                    d = e;
                    e = f;
                    f = g;
                    g = a;
                }
                ", 8.5);
        }

        [TestMethod]
        public void ArrayAccess()
        {
            TestUtils.Benchmark(@"
                function f() {
                    var x = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
                    var sum = 0;
                    for (var i = 0; i < 100000; i ++)
                        sum = x[0] - x[1] - x[2] - x[3] - x[4] - x[5] - x[6] - x[7] - x[8] - x[9];
                }
                f()
                ", 28.5);
        }

        [TestMethod]
        public void ArrayLength()
        {
            TestUtils.Benchmark(@"
                function f() {
                    var x = [1, 2, 3];
                    var sum = 0;
                    for (var i = 0; i < 100000; i ++)
                        for (var j = 0; j < x.length; j ++)
                            sum -= x[j];
                }
                f()
                ", 6.2);
        }

        [TestMethod]
        public void ArrayPopulate()
        {
            TestUtils.Benchmark(@"
                function f() {
                    var x = [];
                    for (var i = 0; i < 100000; i ++)
                        x[i] = i;
                }
                f()
                ", 25.5);
        }
    }

}