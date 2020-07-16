using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymTracker.Data;
using GymTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GymTracker.Pages.Sessions
{
    public class EditModel : PageModel
    {

        private readonly ISessionData sessionData;
        private readonly IExerciseData exerciseData;

        [BindProperty]
        public Session Session { get; set; }
        public IEnumerable<Exercise> Exercise { get; set; }

        public EditModel(ISessionData sessionData, IExerciseData exerciseData)
        {
            this.sessionData = sessionData;
            this.exerciseData = exerciseData;
        }
        
        public IActionResult OnGet(int sessionId)
        {
            Session = sessionData.GetById(sessionId);
            Exercise = exerciseData.GetById(sessionId);
            if(Session == null)
            {
                return RedirectToPage("../NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                sessionData.Update(Session);
                sessionData.Commit();
                return RedirectToPage("./SessionDetail", new { sessionId = Session.SessionId });
            }
            return Page();
        }
    }
}