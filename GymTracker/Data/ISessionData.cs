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
        Session Update(Session updatedSession);
        Session Add(Session newSession);
        int Commit();
    }

    public class InMemorySessionData : ISessionData
    {
        readonly List<Session> sessions;

        public InMemorySessionData()
        {
            sessions = new List<Session>()
            {
                new Session {SessionId = 1, Name = "5/3/1 Week 1 Day 1", Date = DateTime.Parse("6/7/2020") },
                new Session {SessionId = 2, Name = "5/3/1 Week 1 Day 2", Date = DateTime.Parse("7/7/2020") },
                new Session {SessionId = 3, Name = "5/3/1 Week 1 Day 3", Date = DateTime.Parse("8/7/2020") }
            };
        }

        public int Commit()
        {
            return 0;
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

        public Session Add(Session newSession)
        {
            sessions.Add(newSession);
            newSession.SessionId = sessions.Max(r => r.SessionId) + 1;
            return newSession;
        }

        public Session Update(Session updatedSession)
        {
            var session = sessions.SingleOrDefault(s => s.SessionId == updatedSession.SessionId);
            if(session != null)
            {
                session.Name = updatedSession.Name;
                session.Date = updatedSession.Date;
            }
            return session;
        }
    }
}
