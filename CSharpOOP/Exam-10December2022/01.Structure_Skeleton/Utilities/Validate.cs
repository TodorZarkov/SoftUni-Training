namespace ChristmasPastryShop.Utilities
{
    using ChristmasPastryShop.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public static class Validate
    {
        public static Type GetIfType(string typeName)
        {
            Assembly assembly = Assembly.GetEntryAssembly();
            Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == typeName);
            return type;
        }
    }
}
