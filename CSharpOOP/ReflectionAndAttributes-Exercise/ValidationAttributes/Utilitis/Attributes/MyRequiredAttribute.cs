using ValidationAttributes.Attributes.Contracts;

namespace ValidationAttributes.Attributes
{
    using System;
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
        => obj != null;
    }
}
