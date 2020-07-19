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
        private readonly ISessionData sessionData;

        [TempData]
        public string Message { get; set; }
        public IEnumerable<Exercise> Exercises { get; set; }
        public Session Session { get; set; }

        public SessionDetailModel(IExerciseData exerciseData, ISessionData sessionData)
        {
            this.exerciseData = exerciseData;
            this.sessionData = sessionData;
        }

        public IActionResult OnGet(int sessionId)
        {
            Exercises = exerciseData.GetBySession(sessionId);
            Session = sessionData.GetById(sessionId);
            System.Console.WriteLine(Exercises);

            if(Session == null || Exercises.Any() == false)
            {
                return RedirectToPage("../NotFound");
            }
            return Page();
        }
    }
}