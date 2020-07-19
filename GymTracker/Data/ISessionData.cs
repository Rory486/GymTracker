using GymTracker.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymTracker.Data
{
    public interface ISessionData
    {
        IEnumerable<Session> GetAll();
        Session GetById(int id);
        Session Update(Session updatedSession);
        Session Add(Session newSession);
        Session Delete(int id);
        int Commit();
    }
}
