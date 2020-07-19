using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GymTracker.Models
{
    public class Session
    {
        public int SessionId { get; set; }
        [Required, StringLength(80)]
        public string Name { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public ICollection<Exercise> Exercises { get; set; }
    }
}
