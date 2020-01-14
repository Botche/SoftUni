using System;

namespace CustomTestingFramework.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class TestClassAttribute : Attribute
    {

    }
}
