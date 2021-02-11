using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CalendarEvent
    {
        public string Id { get; set; }
        public string CalendarId { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IEnumerable<string> Attendees { get; set; }
        public int ColorId { get; set; }

        public string Summay { get; set; }
        public string Organizer { get; set; }
        public string Description { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        //And you can more

        public CalendarEvent()
        {

        }
        public CalendarEvent(string summay, string organizer, string description, string startTime, string endTime)
        {
            Summay = summay;
            Organizer = organizer;
            Description = description;
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}
