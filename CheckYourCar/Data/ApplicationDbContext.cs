using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CheckYourCar.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<VehicleRecall> VehicleRecalls {
            get; set;
        }
        public DbSet<CarMake> CarsMake { get; set; }

        public DbSet<CarModel> CarsModel { get; set; }

    }
}
