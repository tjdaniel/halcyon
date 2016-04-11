﻿using System;

namespace Halcyon.HAL.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class HalModelAttribute : Attribute
    {
        public string LinkBase { get; }
        public bool ForceHal { get; }

        public HalModelAttribute(string linkBase, bool forceHAL = false)
        {
            LinkBase = linkBase;
            ForceHal = forceHAL;
        }
    }
}
