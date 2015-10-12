using System;
using MitchellClaimDomain.Classes.Entities;
using MitchellClaimDomain.Classes.Interfaces;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace MitchellClaimDomain.DataModel
{
    public class MitchellClaimContext : DbContext
    {
        public DbSet<MitchellClaimType> MitchellClaimTypes { get; set; }
        public DbSet<VehicleInfoType> VehicleInfoTypes { get; set; }
        public DbSet<LossInfoType> LossInfoTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Types().
                Configure(c => c.Ignore("IsDirty"));

            modelBuilder
                .Entity<MitchellClaimType>()
                .Property(p => p.ClaimNumber)
                .HasMaxLength(255);

            modelBuilder
                .Entity<MitchellClaimType>()
                .Property(t => t.ClaimNumber)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute() { IsUnique = true }))
                .IsRequired();

            modelBuilder.Entity<MitchellClaimType>()
            .HasOptional<LossInfoType>(u => u.LossInfo)    
            .WithRequired(c => c.Claim).Map(p => p.MapKey("ClaimId"))
            .WillCascadeOnDelete();


            modelBuilder
                .Entity<VehicleInfoType>()
                .Property(t => t.Mileage)
                .IsOptional();

            modelBuilder
               .Entity<VehicleInfoType>()
               .Property(t => t.LicPlateExpDate)
               .IsOptional();


            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var history in this.ChangeTracker.Entries()
              .Where(e => e.Entity is IModificationHistory && (e.State == EntityState.Added ||
                      e.State == EntityState.Modified))
               .Select(e => e.Entity as IModificationHistory)
              )
            {
                history.DateModified = DateTime.Now;
                if (history.DateCreated == DateTime.MinValue)
                {
                    history.DateCreated = DateTime.Now;
                }
            }
            int result = base.SaveChanges();
            foreach (var history in this.ChangeTracker.Entries()
                                          .Where(e => e.Entity is IModificationHistory)
                                          .Select(e => e.Entity as IModificationHistory)
              )
            {
                history.IsDirty = false;
            }
            return result;
        }

    }
}
