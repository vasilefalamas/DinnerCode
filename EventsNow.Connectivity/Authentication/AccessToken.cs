using System;

namespace EventsNow.Connectivity.Authentication
{
    public class AccessToken
    {
        public string Value { get; private set; }

        public DateTime Expiry { get; private set; }

        public AccessToken(string value, DateTime expiry)
        {
            Value = value;
            Expiry = expiry;
        }
    }
}
