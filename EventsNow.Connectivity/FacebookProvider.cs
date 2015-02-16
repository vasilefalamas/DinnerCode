using System;
using System.Json;
using System.Net.Http;
using System.Threading.Tasks;
using EventsNow.Connectivity.Authentication;
using EventsNow.Connectivity.GraphApi;

namespace EventsNow.Connectivity
{
    public class FacebookProvider
    {
        private readonly HttpClient httpClient;

        public FacebookProvider()
        {
            httpClient = new HttpClient();
        }

        public async Task<Event> GetEventAsync(AccessToken accessToken, string eventId)
        {
            var response = await httpClient.GetStringAsync(FacebookUriProvider.GetEventInfoUri(accessToken, eventId));

            JsonObject jsonObject = JsonValue.Parse(response).ToJsonObject();

            var facebookEvent = new Event
            {
                Id = eventId,
                Title = (string) jsonObject.GetValue("name"),
                Description = (string) jsonObject.GetValue("description"),
                StartDate = (DateTime) jsonObject.GetValue("start_time"),
                EndDate = (DateTime) jsonObject.GetValue("end_time"),
                Location = await GetLocationAsync(eventId)
            };


            return facebookEvent;
        }

        public async Task<Location> GetLocationAsync(string locationId)
        {
            var response = await httpClient.GetStringAsync(FacebookUriProvider.GetLocationIdUri(locationId));

            JsonObject jsonObject = JsonValue.Parse(response).ToJsonObject();

            return new Location
            {
                Id = Convert.ToInt64(jsonObject.GetValue("id")),
                Name = (string) jsonObject.GetValue("name"),
                Latitude = Convert.ToInt64(jsonObject.GetValue("location")),
                Longitude = Convert.ToInt64(jsonObject.GetValue("location"))
            };
        }
    }
}
