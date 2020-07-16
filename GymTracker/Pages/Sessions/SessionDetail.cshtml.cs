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
        public IEnumerable<Exercise> Exercise { get; set; }
        public Session Session { get; set; }

        public SessionDetailModel(IExerciseData exerciseData, ISessionData sessionData)
        {
            this.exerciseData = exerciseData;
            this.sessionData = sessionData;
        }

        public IActionResult OnGet(int sessionId)
        {
            Exercise = exerciseData.GetById(sessionId);
            Session = sessionData.GetById(sessionId);
            if(Session == null)
            {
                return RedirectToPage("../NotFound");
            }
            return Page();
        }
    }
}