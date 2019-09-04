using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

using CustomTestingFramework.Utilities;
using CustomTestingFramework.Attributes;
using CustomTestingFramework.Exceptions;
using CustomTestingFramework.TestRunner.Contracts;

namespace CustomTestingFramework.TestRunner
{
    public class Runner : ITestRunner
    {
        private readonly ICollection<string> resultInfo;

        public Runner()
        {
            resultInfo = new List<string>();
        }

        public ICollection<string> Run(string assemblyPath)
        {
            var testClasses = Assembly
                .LoadFrom(assemblyPath)
                .GetTypes()
                .Where(t => t.HasAttribute<TestClassAttribute>())
                .ToList();

            foreach (var testClass in testClasses)
            {
                var testMethods=testClass
                    .GetMethods()
                    .Where(m => m.HasAttribute<TestMethodAttribute>())
                    .ToList();

                var testClassInstance = Activator.CreateInstance(testClass);

                foreach (var testMethod in testMethods)
                {
                    try
                    {
                        testMethod.Invoke(testClassInstance, null);

                        resultInfo.Add($"Method: {testMethod.Name} - passed!");
                    }
                    catch (TestException)
                    {
                        resultInfo.Add($"Method: {testMethod.Name} - failed!");
                    }
                    catch
                    {
                        resultInfo.Add($"Method: {testMethod.Name} - unexpected error occured!");
                    }
                }
            }

            return resultInfo;
        }
    }
}
