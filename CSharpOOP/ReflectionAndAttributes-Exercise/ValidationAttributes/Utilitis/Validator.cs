namespace ValidationAttributes.Utilitis
{
    using System;
    using System.Linq;
    using System.Reflection;

    using ValidationAttributes.Attributes.Contracts;

    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type type = obj.GetType();
            var properties = type.GetProperties()
                .Where(p => p.CustomAttributes
                .Any(a => typeof(MyValidationAttribute).IsAssignableFrom(a.AttributeType)))
                .ToArray();

            foreach (var property in properties)
            {
                var customAttributes = property
                    .GetCustomAttributes()
                    .Where(c => typeof(MyValidationAttribute).IsAssignableFrom(c.GetType())).ToArray();
                object propertyValue = property.GetValue(obj);
                foreach (var customAttribute in customAttributes)
                {
                    Type attributeType = customAttribute.GetType();
                    MethodInfo isValidMethod = attributeType.GetMethods().FirstOrDefault(m => m.Name == "IsValid");
                    if (isValidMethod ==null)
                    {
                        throw new InvalidOperationException("IsValid method not implemented.");
                    } 
                    bool result = (bool)isValidMethod.Invoke(customAttribute, new object[] { propertyValue });

                    if (!result)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
