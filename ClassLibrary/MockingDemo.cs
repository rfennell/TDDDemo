using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class MockingDemo
    {
        private IDateTimeProvider datetimeProvider;

        public MockingDemo()
        {
            this.datetimeProvider = new MyDateTimeProvider();
        }

        public MockingDemo(IDateTimeProvider datetimeProvider)
        {
            this.datetimeProvider = datetimeProvider;
        }

        public DateTime GetDateTime()
        {
            return this.datetimeProvider.GetDateTime();
        }
    }
}
