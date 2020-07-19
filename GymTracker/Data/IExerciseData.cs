using GymTracker.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymTracker.Data
{
    public interface IExerciseData
    {
        IEnumerable<Exercise> GetBySession(int id);
        Exercise Update(Exercise updatedExercise);
        Exercise Add(Exercise newExercise);
        int Commit();
    }
}
