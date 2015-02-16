using System;
using EventsNow.Connectivity.Authentication;

namespace EventsNow.Connectivity
{
    public class FacebookUriProvider
    {
        public static Uri GetUserNameInfoUri(AccessToken accessToken)
        {
            return new Uri(string.Format("https://graph.facebook.com/me?access_token={0}", accessToken.Value));
        }

        public static Uri GetLocationIdUri(string locationId)
        {
            return new Uri(string.Format("https://graph.facebook.com/{0}", locationId));
        }

        public static Uri GetEventInfoUri(AccessToken accessToken, string eventId)
        {
            return new Uri(string.Format("https://graph.facebook.com/{0}?access_token={1}", eventId, accessToken.Value));
        }

    }
}
