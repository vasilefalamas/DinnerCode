using System;

namespace EventsNow.Connectivity.GraphApi
{
    public class Event
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public Location Location { get; set; }
    }
}
