namespace SoftUniBazar.Common.Services
{
    using SoftUniBazar.Common.Services.Interfaces;
    using System;

    public class DateTimeNowProvider : IDateTimeProvider
    {
        public DateTime GetCurrentDate()
        {
            return DateTime.Now.Date;
        }

        public DateTime GetCurrentDateTime()
        {
            return DateTime.Now;
        }
    }
}
