using GymTracker.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GymTracker.Data
{
    public class SqlSessionData : ISessionData
    {
        private readonly GymTrackerDbContext db;

        public SqlSessionData(GymTrackerDbContext db)
        {
            this.db = db;
        }

        public Session Add(Session newSession)
        {
            db.Add(newSession);
            return newSession;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Session Delete(int id)
        {
            var session = GetById(id);
            if(session != null)
            {
                db.Sessions.Remove(session);
            }
            return session;
        }

        public Session GetById(int id)
        {
            return db.Sessions.Find(id);
        }

        public IEnumerable<Session> GetAll()
        {
            return db.Sessions;
        }

        public Session Update(Session updatedSession)
        {
            var entity = db.Sessions.Attach(updatedSession);
            entity.State = EntityState.Modified;
            return updatedSession;
        }
    }
}
