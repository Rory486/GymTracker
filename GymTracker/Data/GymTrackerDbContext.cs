﻿using GymTracker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymTracker.Data
{
    public class GymTrackerDbContext : DbContext
    {
        public DbSet<Session> Sessions { get; set; }
    }
}
