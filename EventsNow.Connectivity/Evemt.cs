using System;

namespace EventsNow.Connectivity
{
    public class Evemt
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public Location Location { get; set; }
    }
}
