using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymTracker.Models
{
    public class Session
    {
        public int SessionId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
