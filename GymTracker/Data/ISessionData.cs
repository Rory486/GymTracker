using GymTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymTracker.Data
{
    public interface ISessionData
    {
        IEnumerable<Session> GetAll();
        Session GetById(int id);
    }

    public class InMemorySessionData : ISessionData
    {
        List<Session> sessions;

        public InMemorySessionData()
        {
            sessions = new List<Session>()
            {
                new Session {SessionId = 1, Name = "5/3/1 Week 1 Day 1", Date = DateTime.Parse("6/7/2020") },
                new Session {SessionId = 2, Name = "5/3/1 Week 1 Day 2", Date = DateTime.Parse("7/7/2020") },
                new Session {SessionId = 3, Name = "5/3/1 Week 1 Day 3", Date = DateTime.Parse("8/7/2020") }
            };
        }

        public IEnumerable<Session> GetAll()
        {
            return from s in sessions
                   orderby s.Date descending
                   select s;
        }

        public Session GetById(int id)
        {
            return sessions.SingleOrDefault(r => r.SessionId == id);
        }
    }
}
