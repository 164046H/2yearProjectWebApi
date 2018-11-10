using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EMS.Data.Models
{
    public class Event
    {
        public string EventTitle { get; set; }
        public string EventDescription { get; set; }
        public string Destination { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Key]
        public string PKey { get; set; }
        public string Url { get; set; }
    }
}
