namespace ValidationAttributes.Attributes
{
    using System;
    
    using Contracts;

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class MyRangeAttribute : MyValidationAttribute
    {
        int minValue;
        int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            return (int)obj >= minValue && (int)obj <= maxValue;
        }
    }
}
