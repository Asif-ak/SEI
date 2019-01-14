using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEIAPI.DbConfiguration
{
    public class APIContext:DbContext
    {
        public APIContext(DbContextOptions<APIContext> contextOptions):base(contextOptions)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.ApplicantRegistration>()
                .HasOne(s => s.LoginCredential)
                .WithOne(a => a.Registration)
                .HasForeignKey<Models.LoginCredentials>(a => a.RegistrationID);
        }

        public DbSet<Models.LoginCredentials> LoginCredentials { get; set; }
        public DbSet<Models.ApplicantRegistration> ApplicantRegistrations { get; set; }
    }
}
