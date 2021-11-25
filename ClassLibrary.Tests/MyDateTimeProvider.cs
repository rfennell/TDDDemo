using System;

namespace ClassLibrary.Test
{
    public class MyTestDateTimeProvider : IDateTimeProvider
    {
        private DateTime dateTime;
        public MyTestDateTimeProvider(DateTime seed)
        {
            this.dateTime = seed;
        }
        public DateTime GetDateTime()
        {
            return this.dateTime;
        }
    }
}