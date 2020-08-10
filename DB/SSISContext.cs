using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SSIS_BOOT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSIS_BOOT.DB
{
    public class SSISContext : DbContext
    {
        protected IConfiguration configuration;

        public SSISContext(DbContextOptions<SSISContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder model)
        {
            //// unique name within a column
            //model.Entity<Cinema>().HasIndex(tbl => tbl.Name).IsUnique();

            //// composite keys
            //model.Entity<Seat>().HasAlternateKey(tbl =>
            //    new { tbl.ScreeningId, tbl.Row, tbl.Col }
            //);
        }

        public DbSet<AdjustmentVoucher> AdjustmentVouchers { get; set; }
        public DbSet<AdjustmentVoucherDetail> AdjustmentVoucherDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CollectionPoint> CollectionPoints { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public DbSet<PurchaseRequestDetail> PurchaseRequestDetails { get; set; }
        public DbSet<Requisition> Requisitions { get; set; }
        public DbSet<RequisitionDetail> RequisitionDetails { get; set; }
        public DbSet<Retrieval> Retrievals { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<TenderQuotation> TenderQuotations { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
