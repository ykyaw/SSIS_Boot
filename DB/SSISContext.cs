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
            //model.Entity<Employee>().HasMany(e => e.Employees).WithOne(e => e.Manager).HasForeignKey(e => e.ManagerId); // this fix the self referencing in Employee
            //model.Entity<Department>().Ignore(x => x.Rep).Ignore(x => x.Head);
            //model.Entity<Employee>().Ignore(x => x.Manager);
            //model.Entity<Requisition>().Ignore(x => x.ReqByEmp).Ignore(x => x.ApprovedBy).Ignore(x => x.ProcessedByClerk).Ignore(x => x.ReceivedByRep).Ignore(x => x.AckByClerk);
            //model.Entity<AdjustmentVoucher>().Ignore(x => x.InitiatedClerk).Ignore(x => x.ApprovedSup).Ignore(x => x.ApprovedMgr);
            //model.Entity<PurchaseOrder>().Ignore(x => x.Supplier).Ignore(x => x.OrderedByClerk).Ignore(x => x.ApprovedBySup).Ignore(x => x.ReceivedByClerk);
            //model.Entity<PurchaseRequestDetail>().Ignore(x => x.CreatedByClerk).Ignore(x => x.Supplier).Ignore(x => x.ApprovedBySup);
            //model.Entity<Retrieval>().Ignore(x => x.Clerk);
            //model.Entity<Transaction>().Ignore(x => x.Product).Ignore(x => x.UpdatedByEmp);

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
        public DbSet<Transaction> Transactions { get; set; }//a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3
    }
}
