namespace EventsNow.Connectivity.GraphApi
{
    public class User
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public string ProfilePictureUri { get; set; }

        public Location Location { get; set; }
    }
}
