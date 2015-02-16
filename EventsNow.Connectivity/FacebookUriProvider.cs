using System;
using EventsNow.Connectivity.Authentication;

namespace EventsNow.Connectivity
{
    public class FacebookUriProvider
    {
        private const string AppId = "34234234234";

        private const string ProductId = "msft-342342342"; 

        public static Uri GetConnectionUri()
        {
            var defaultPermissions = string.Join(",", new[] { Permissions.PublicProfile, Permissions.ReadStream, Permissions.UserEvents, Permissions.UserLocation });

            return new Uri(string.Format(@"fbconnect://authorize?client_id={0}&scope={1}&redirect_uri=msft-{2}://authorize", AppId, defaultPermissions, ProductId));
        }

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
