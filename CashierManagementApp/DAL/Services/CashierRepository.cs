using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CashierManagementApp.DAL.Interfaces;

namespace CashierManagementApp.DAL.Services
{
    public class CashierRepository : Interfaces.ICashierRepository
    {
        private CashierDbContext _context;

        public CashierRepository(CashierDbContext context)
        {
            _context = context;
        }

        public Model.CashierModel GetById(string id)
        {
            return _context.CashierModels.FirstOrDefault(t => t.Id == int.Parse(id));
        }

        public string GetAll()
        {
            string qry = "select* from CashierModels";
            return qry;
        }

        public string Add()
        {
            string qry = "insert into CashierModels(Title, IsCompleted, DueDate)" +
                "values('";
            return qry;
        }

        public string Update()
        {
            var query = "update CashierModels set Title='";
            return query;
        }

        public string Delete()
        {
            var query = "delete from CashierModels where Id='";
            return query;
        }
    }
}