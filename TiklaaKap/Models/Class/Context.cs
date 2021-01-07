using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TiklaaKap.Models.Class
{
    public class Context : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Cariler> Carilers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<InvoiceData> InvoiceDatas { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}