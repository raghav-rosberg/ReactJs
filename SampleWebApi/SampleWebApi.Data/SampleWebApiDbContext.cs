using Microsoft.AspNet.Identity.EntityFramework;
using SampleWebApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebApi.Data
{
    public class SampleWebApiDbContext : IdentityDbContext<ApplicationUser>
    {
        public SampleWebApiDbContext()
            : base("SampleWebApiDbContext")
        {
            Database.SetInitializer<SampleWebApiDbContext>(null);
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<LocalUser> LocalUser { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
