using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class Command
    {
        public int Id { get; set; }
        public string PayLoad { get; set; }

        public DateTime RequestDate { get; set; }
        public DateTime? CompleteDate { get; set; }

        public Command()
        {
            RequestDate = DateTime.UtcNow;

        }
    }
}