using Microsoft.EntityFrameworkCore;
using PrimeCRM_Api.Domain.Models.Inventario;
using PrimeCRM_Api.Domain.Models.Liquidaciones;
using PrimeCRM_Api.Domain.Models.Masters;
using PrimeCRM_Api.Domain.Models.Reabastecimimento;
using PrimeCRM_Api.Domain.Models.Ventas;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeCRM_Api.Infraestructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        // =========================
        // MASTER DATA
        // =========================
        public DbSet<Brand> Brands { get; set; }

        public DbSet<Product> Products { get; set; }


        public DbSet<CourierCompany> CourierCompanies { get; set; }

        public DbSet<FreightCompany> FreightCompanies { get; set; }

        public DbSet<PaymentMethod> PaymentMethods { get; set; }

        public DbSet<SalesChannel> SalesChannels { get; set; }

        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }

        public DbSet<IncomeCategory> IncomeCategories { get; set; }

        // =========================
        // INVENTORY
        // =========================

        public DbSet<InventoryMovement> InventoryMovements { get; set; }


        // =========================
        // RESTOCKING
        // =========================

        public DbSet<RestockOrder> RestockOrders { get; set; }


        // =========================
        // SALES
        // =========================

        public DbSet<Sale> Sales { get; set; }


        // =========================
        // LIQUIDATIONS
        // =========================

        public DbSet<Liquidation> Liquidations { get; set; }

        public DbSet<LiquidationItem> LiquidationItems { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            ConfigureProduct(modelBuilder);

            

        }
        private void ConfigureProduct(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(e =>
            {
                e.HasOne(p => p.Brand)
                    .WithMany(b => b.Products)
                    .HasForeignKey(p => p.BrandId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
