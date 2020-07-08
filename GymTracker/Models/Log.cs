using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GymTracker.Models
{
    public class Log
    {
        public int LogId { get; set; }
        [Required]
        public int Sets { get; set; }
        [Required]
        public int Reps { get; set; }
        [Required]
        public double Weight { get; set; }

        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
    }
}