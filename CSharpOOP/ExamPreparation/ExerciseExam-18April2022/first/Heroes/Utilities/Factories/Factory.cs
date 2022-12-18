namespace Heroes.Utilities.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class Factory
    {
        public static object Produce(string typeName, params object[] constructorParameters)
        {

            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == typeName);

            if (type == null)
            {
                return null;
            }

            object obj;
            try
            {
                obj = Activator.CreateInstance(type, constructorParameters);
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }

            return obj;

        }
    }
}

