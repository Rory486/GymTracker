
using GymTracker.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GymTracker.Data
{
    public class SqlExerciseData : IExerciseData
    {
        private readonly GymTrackerDbContext db;

        public SqlExerciseData(GymTrackerDbContext db)
        {
            this.db = db;
        }

        public Exercise Add(Exercise newExercise)
        {
            db.Add(newExercise);
            return newExercise;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public IEnumerable<Exercise> GetBySession(int id)
        {
            var query = from e in db.Exercises
                        where e.SessionId == id
                        orderby e.ExerciseId
                        select e;

            return query;
        }

        public Exercise Update(Exercise updatedExercise)
        {
            var entity = db.Exercises.Attach(updatedExercise);
            entity.State = EntityState.Modified;
            return updatedExercise;
        }
    }
}
