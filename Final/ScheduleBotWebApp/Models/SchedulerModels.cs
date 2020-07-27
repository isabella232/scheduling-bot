using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScheduleBotWebApp.Models
{
    public class SchedulerModels
    {
    }

    public class Schedule
    {
        public int ID { get; set; }
        public string UserId { get; set; }
        public DateTime EventDate { get; set; }
        public string EventName { get; set; }
        public int MinutesToAlertBefore { get; set; }
        public bool Completed { get; set; }
        public string PhoneNumber { get; set; }
    }
}