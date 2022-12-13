
namespace Formula1
{

    using System;
    using Formula1;
    using System.Linq;
    using NUnit.Framework;
    using System.Reflection;
    using System.Collections.Generic;

    public class Tests_000_001
    {
        private static readonly Assembly ProjectAssembly = typeof(StartUp).Assembly;

        [Test]
        public void CreateCarWorkProperly()
        {
            var controller = CreateObjectInstance(GetType("Controller"));

            var carArguments = new object[] { "Ferrari", "SF71H", 950, 1.7 };
            var validActualResult = InvokeMethod(controller, "CreateCar", carArguments);

            var validExpectedResult = "Car Ferrari, model SF71H is created.";

            Assert.AreEqual(validExpectedResult, validActualResult);
        }

        private static object InvokeMethod(object obj, string methodName, object[] parameters)
        {
            try
            {
                var result = obj.GetType()
                    .GetMethod(methodName)
                    .Invoke(obj, parameters);

                return result;
            }
            catch (TargetInvocationException e)
            {
                return e.InnerException.Message;
            }
        }

        private static object CreateObjectInstance(Type type, params object[] parameters)
        {
            try
            {
                var desiredConstructor = type.GetConstructors()
                    .FirstOrDefault(x => x.GetParameters().Any());

                if (desiredConstructor == null)
                {
                    return Activator.CreateInstance(type, parameters);
                }

                var instances = new List<object>();

                foreach (var parameterInfo in desiredConstructor.GetParameters())
                {
                    var currentInstance = Activator.CreateInstance(GetType(parameterInfo.Name.Substring(1)));

                    instances.Add(currentInstance);
                }

                return Activator.CreateInstance(type, instances.ToArray());
            }
            catch (TargetInvocationException e)
            {
                return e.InnerException.Message;
            }
        }

        private static Type GetType(string name)
        {
            var type = ProjectAssembly
                .GetTypes()
                .FirstOrDefault(t => t.Name.Contains(name));

            return type;
        }
    }
}