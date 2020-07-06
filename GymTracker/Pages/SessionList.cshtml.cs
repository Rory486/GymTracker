using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using GymTracker.Data;
using GymTracker.Models;

namespace GymTracker.Pages
{
    public class SessionListModel : PageModel
    {
        private ILogger<IndexModel> _logger;
        private readonly ISessionData sessionData;

        public IEnumerable<Session> Sessions { get; set; }

        public SessionListModel(ISessionData sessionData, ILogger<IndexModel> logger)
        {
            _logger = logger;
            this.sessionData = sessionData;
        }
        public void OnGet()
        {
            Sessions = sessionData.GetAll();
        }
    }
}