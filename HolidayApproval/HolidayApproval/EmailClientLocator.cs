using System;
using HolidayApproval.Mail;

namespace HolidayApproval
{
    public class EmailClientLocator
    {
        private static IEmailClient _emailClient;

        
        public static IEmailClient EmailClient
        {
            get
            {
                return _emailClient;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Email client argument was null.");
                }
                
                _emailClient = value;
            }
        }
    }
}
