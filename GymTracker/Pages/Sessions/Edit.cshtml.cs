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
        //public IEnumerable<Exercise> Exercises { get; set; }

        //add as parameter "IExerciseData exerciseData"
        public EditModel(ISessionData sessionData)
        {
            this.sessionData = sessionData;
            //this.exerciseData = exerciseData;
        }
        
        public IActionResult OnGet(int? sessionId)
        {   
            if(sessionId.HasValue)
            {
                Session = sessionData.GetById(sessionId.Value);
                //Exercises = exerciseData.GetById(sessionId.Value);
            }
            else
            {
                Session = new Session();
            }


            if(Session == null)
            {
                return RedirectToPage("../NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();   
            }

            if (Session.SessionId > 0)
            {
                sessionData.Update(Session);
                TempData["Message"] = "Session updated!";
            }
            else
            {
                sessionData.Add(Session);
                TempData["Message"] = "Session added!";
            }
            sessionData.Commit();
            return RedirectToPage("./SessionDetail", new { sessionId = Session.SessionId });
        }
    }
}