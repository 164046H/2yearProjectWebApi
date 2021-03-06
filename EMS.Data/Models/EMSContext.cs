﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EMS.Data.Models
{
    public class EMSContext : IdentityDbContext<ApplicationUser>
    {
        //  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-RUHANGI\SQLEXPRESS;Initial Catalog=DBApi5;Integrated Security=True");
        //}

        public EMSContext(DbContextOptions<EMSContext> options) : base(options)
        {

        }
       
        public DbSet<Employee> Event { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<OneDayTripRegistrant> OneDayTripRegistrants { get; set; }
        public DbSet<TwoDayTripRegistrants> TwoDayTripRegistrant { get; set; }

    }
}
