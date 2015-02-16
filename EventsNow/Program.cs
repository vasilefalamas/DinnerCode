using System;
using System.Threading.Tasks;
using EventsNow.Connectivity;
using EventsNow.Connectivity.Authentication;

namespace EventsNow
{
    class Program
    {
        static void Main()
        {
            AccessToken accessToken = new AccessToken("", DateTime.Now); 

            try
            {
                var loginTask = Login(FacebookUriProvider.GetConnectionUri());
                loginTask.Wait();

                //More logic to retrieve access token
            }
            catch (Exception e)
            {
                Console.WriteLine("Login was unsuccesful. {0} \n {1}", e.GetType(), e.Message);
                return;
            }
            
            FacebookProvider fbProvider = new FacebookProvider();

            var getUserDataTask = fbProvider.GetUserDataAsync(accessToken);
            getUserDataTask.Wait();

            var thisUser = getUserDataTask.Result;
            
            Console.WriteLine("Hello, {0}", thisUser.FullName);

            var getEventDataTask = fbProvider.GetEventAsync(accessToken, "1");
            getEventDataTask.Wait();

            var thisEvent = getEventDataTask.Result;

            Console.WriteLine("{0} goes to {1}.\n{1} takes place in {2} and starts {3}", 
                thisUser.FullName,
                thisEvent.Title,
                thisEvent.Location.Name,
                thisEvent.StartDate);


        }

        private async static Task Login(Uri connectionUri)
        {
            //await Launcher.LaunchUriAsync(connectionUri); - WinRT specific...
        }
    }
}
