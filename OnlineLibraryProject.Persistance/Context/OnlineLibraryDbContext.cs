using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineLibraryProject.Domain.Abstractions;
using OnlineLibraryProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibraryProject.Persistance.Context
{
    public class OnlineLibraryDbContext : IdentityDbContext<User, Role, string>
    {
        public OnlineLibraryDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyReference).Assembly);

            modelBuilder.Ignore<IdentityUserLogin<string>>();
            modelBuilder.Ignore<IdentityUserRole<string>>();
            modelBuilder.Ignore<IdentityUserClaim<string>>();
            modelBuilder.Ignore<IdentityUserToken<string>>();
            modelBuilder.Ignore<IdentityRoleClaim<string>>();
            modelBuilder.Ignore<IdentityRole<string>>();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<Entity>();
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                    entry.Property(e => e.CreateTime).CurrentValue = DateTime.UtcNow;

                if (entry.State == EntityState.Modified)
                    entry.Property(e => e.UpdateTime).CurrentValue = DateTime.UtcNow;
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
