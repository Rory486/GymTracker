using GymTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymTracker.Data
{
    public interface IExerciseData
    {
        IEnumerable<Exercise> GetById(int id);
    }

    public class InMemoryExerciseData : IExerciseData
    {
        List<Exercise> exercises;

        public InMemoryExerciseData()
        {
            exercises = new List<Exercise>()
            {
                new Exercise {ExerciseId=1, ExerciseName="Bench Press", Sets=1, Reps=5, Weight=65.5, SessionId=1 },
                new Exercise {ExerciseId=2, ExerciseName="Bench Press", Sets=3, Reps=5, Weight=70.0, SessionId=1 },
                new Exercise {ExerciseId=3, ExerciseName="Overhead Press", Sets=1, Reps=5, Weight=30.0, SessionId=1 },
                new Exercise {ExerciseId=4, ExerciseName="Overhead Press", Sets=3, Reps=5, Weight=41.0, SessionId=1 },
                new Exercise {ExerciseId=5, ExerciseName="Squat", Sets=3, Reps=5, Weight=97.5, SessionId=2 },
                new Exercise {ExerciseId=6, ExerciseName="Deadlift", Sets=5, Reps=10, Weight=50.0, SessionId=2 },
                new Exercise {ExerciseId=7, ExerciseName="Chinups", Sets=3, Reps=5, Weight=10.0, SessionId=3 },
                new Exercise {ExerciseId=8, ExerciseName="Barbell Rows", Sets=5, Reps=10, Weight=62.5, SessionId=3 }
            };
        }

        public IEnumerable<Exercise> GetById(int id)
        {
            return from e in exercises
                   where e.SessionId == id
                   orderby e.ExerciseId
                   select e;
        }
    }
}
