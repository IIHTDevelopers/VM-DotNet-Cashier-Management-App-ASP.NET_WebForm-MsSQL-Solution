using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using CashierManagementApp.Model;

namespace CashierManagementApp.DAL
{
    public class CashierDbContext : DbContext
    {
        public DbSet<Model.CashierModel> CashierModels { get; set; }

        public CashierDbContext() : base("ConnStr")
        {
        }
    }
}