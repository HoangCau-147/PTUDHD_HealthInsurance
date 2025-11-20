using Entity.Models;
using Entity.Models.Claim;
using Entity.Models.Customers;
using Entity.Models.InsuranceContractModels;
using Entity.Models.InsuranceModels;
using Entity.Models.Staff;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Repository.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class InsuranceDBContext : IdentityDbContext<User>
    {
        public InsuranceDBContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base .OnModelCreating(modelBuilder);


            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            // insurance
            modelBuilder.Entity<InsuranceBenefitCost>().HasKey(e
                => new { e.PolicyId, e.BenefitId, e.ProgramId });
            modelBuilder.Entity<InsurancePrice>().HasKey(e
                => new { e.PolicyId, e.ProgramId });
            modelBuilder.Entity<ContractHealthCondition>().HasKey(e
                => new { e.ContractId, e.HealthConditionId });
            modelBuilder.Entity<InsuranceBenefit>(entity =>
            {
                entity.Property(e => e.BenefitId).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            });
            modelBuilder.Entity<InsuranceBenefitType>(entity =>
            {
                entity.Property(e => e.BenefitTypeId).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            });
            modelBuilder.Entity<InsuranceProgram>(entity =>
            {
                entity.Property(e => e.ProgramId).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            });
            // claim
            modelBuilder.Entity<ClaimHealthService>().HasKey(e
                => new { e.ClaimPaymentId, e.Id });

            // contract
            modelBuilder.Entity<ContractInvoice>().HasKey(e
                => new { e.Id, e.ContractID });
            
            modelBuilder.Entity<ClaimRequest>(entity
                =>
            {   
                entity.HasOne<Customer>(e => e.Customer)
                .WithMany(e => e.Claims)
                .HasForeignKey(e => e.CustomerId)
                .OnDelete(DeleteBehavior.SetNull);
                
            } );
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(p => p.EmployeeId)
                .IsUnique();
                entity.Property(e => e.EmployeeId).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            });

            modelBuilder.Entity<InsuranceProduct>(entity =>
            {
                entity.HasMany<HealthCondition>(e => e.HealthConditionSource)
                .WithOne(g => g.Product)
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.Property(e => e.ProductId).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            });

            // customer
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            });
        }
        #region Dbset
        public DbSet<InsuranceProduct>? InsuranceProducts { get; set; }
        public DbSet<InsurancePrice>? InsurancePrices { get; set; }
        public DbSet<InsuranceProgram>? InsurancePrograms { get; set; }
        public DbSet<InsuranceBenefit>? InsuranceBenefits { get; set; }
        public DbSet<InsuranceBenefitCost>? InsuranceBenefitCosts { get; set; }
        public DbSet<Employee>? Employees { get; set; }
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<ClaimHealthService>? ClaimHealthServices { get; set; }
        public DbSet<ClaimInvoice>? ClaimInvoice { get; set;}
        public DbSet<ClaimPayment>? ClaimPayment { get; set; }
        public DbSet<ClaimRequest>? ClaimRequests { get; set; }
        public DbSet<Contract>? Contracts { get; set; }
        public DbSet<ContractInvoice>? ContractsInvoice { get; set; }
        public DbSet<HealthCondition>? HealthConditions { get; set; }
        public DbSet<ContractHealthCondition>? ContractHealthConditions { get; set;}
        //public DbSet<HealthConditionInsuranceProduct>? healthConditionInsuranceProducts { get; set; }
        #endregion
    }
}
