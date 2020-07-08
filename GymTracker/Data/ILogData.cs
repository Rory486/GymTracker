using GymTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymTracker.Data
{
    public interface ILogData
    {
        IEnumerable<Log> GetLogById(int id);
    }

    public class InMemoryLogData : ILogData
    {
        List<Log> logs;

        public InMemoryLogData()
        {
            logs = new List<Log>()
            {
                new Log { LogId=1, Sets=1, Reps=5, Weight=65.5, ExerciseId=1 },
                new Log { LogId=2, Sets=3, Reps=5, Weight=70.0, ExerciseId=1 },
                new Log { LogId=3, Sets=1, Reps=5, Weight=30.0, ExerciseId=2 },
                new Log { LogId=4, Sets=3, Reps=5, Weight=41.0, ExerciseId=2 },
                new Log { LogId=5, Sets=3, Reps=5, Weight=97.5, ExerciseId=3 },
                new Log { LogId=6, Sets=5, Reps=10, Weight=50.0, ExerciseId=4 },
                new Log { LogId=7, Sets=3, Reps=5, Weight=10.0, ExerciseId=5 },
                new Log { LogId=8, Sets=5, Reps=10, Weight=62.5, ExerciseId=6 }
            };
        }

        public IEnumerable<Log> GetLogById(int id)
        {
            return from l in logs
                   where l.ExerciseId == id
                   orderby l.LogId
                   select l;
        }
    }
}
