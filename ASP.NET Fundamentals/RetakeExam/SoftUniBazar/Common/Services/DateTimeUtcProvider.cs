namespace SoftUniBazar.Common.Services
{
    using SoftUniBazar.Common.Services.Interfaces;
    using System;

    public class DateTimeUtcProvider : IDateTimeProvider
    {
        public DateTime GetCurrentDate()
        {
            return DateTime.UtcNow.Date;
        }

        public DateTime GetCurrentDateTime()
        {
            return DateTime.UtcNow;
        }
    }
}
