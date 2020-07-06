using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GymTracker.Models
{
    public class Exercise
    {
        public int ExerciseId { get; set; }
        [Required]
        public string ExerciseName { get; set; }

    }
}
