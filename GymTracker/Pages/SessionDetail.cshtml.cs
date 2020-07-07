using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymTracker.Data;
using GymTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GymTracker.Pages
{
    public class SessionDetailModel : PageModel
    {
        private readonly IExerciseData exerciseData;
        public IEnumerable<Exercise> Exercise { get; set; }

        public SessionDetailModel(IExerciseData exerciseData)
        {
            this.exerciseData = exerciseData;
        }

        public void OnGet(int sessionId)
        {
            Exercise = exerciseData.GetById(sessionId);
        }
    }
}