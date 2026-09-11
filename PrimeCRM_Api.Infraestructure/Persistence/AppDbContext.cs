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
                e.HasKey(p=> p.Id);

                e.HasOne(p => p.Brand)
                    .WithMany(b => b.Products)
                    .HasForeignKey(p => p.BrandId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            
        }

        private void ConfigureInventoryMovement(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InventoryMovement>(e =>
            {
                e.HasKey(i => i.Id);

                e.HasOne(i => i.Product)
                    .WithMany(p => p.InventoryMovements)
                    .HasForeignKey(im => im.ProductID)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private void RestockConfigure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RestockOrder>(e =>
            {
                e.HasKey(ro => ro.Id);

                e.HasOne(ro => ro.Product)
                    .WithMany(p => p.RestockOrders)
                    .HasForeignKey(ro => ro.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);


                e.HasOne(ro => ro.FreightCompany)
                    .WithMany(fc => fc.RestockOrders)
                    .HasForeignKey(ro => ro.FreightCompanyId)
                    .OnDelete(DeleteBehavior.Restrict);
                
                e.HasOne(ro=> ro.PaymentMethod)
                    .WithMany(pm => pm.RestockOrders)
                    .HasForeignKey(ro => ro.PaymentMethodId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private void ConfigureSale(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sale>(e =>
            {
                e.HasKey(s => s.Id);

                e.HasOne(s => s.Product)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(s => s.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(s=> s.CourierCompany)
                    .WithMany(cc => cc.Sales)
                    .HasForeignKey(s => s.CourierCompanyId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(s => s.SalesChannel)
                    .WithMany(sc => sc.Sales)
                    .HasForeignKey(s => s.SalesChannelId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private void ConfigureLiquidation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LiquidationItem>(e =>
            {
                e.HasKey(l => l.Id);

                e.HasOne(l => l.Sale)
                    .WithOne(s => s.LiquidationItem)
                    .HasForeignKey<LiquidationItem>(li => li.Tracking)
                    .OnDelete(DeleteBehavior.Restrict);


                e.HasOne(li => li.Liquidation)
                    .WithMany(l => l.Trackings)
                    .HasForeignKey(li => li.LiquidationId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            
        }
    }
}
