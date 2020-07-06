using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GymTracker.Models
{
    public class Set
    {
        public int SetId { get; set; }
        [Required]
        public int Reps { get; set; }
        [Required]
        public double Weight { get; set; }
        public int ExerciseId { get; set; }

    }
}
