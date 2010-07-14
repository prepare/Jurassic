﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jurassic.Compiler
{
    /// <summary>
    /// Represents a javascript primitive type.
    /// </summary>
    internal enum PrimitiveType
    {
        Undefined,  // Jurassic.Undefined
        Null,       // Jurassic.Null
        Any,        // System.Object
        Bool,       // System.Boolean
        Number,     // System.Double
        Int32,      // System.Int32
        UInt32,     // System.UInt32
        String,     // System.String
        Object,     // Jurassic.Library.ObjectInstance
    }
}
