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

        public IActionResult OnGet(int sessionId)
        {
            Exercise = exerciseData.GetById(sessionId);
            if(!Exercise.Any())
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}