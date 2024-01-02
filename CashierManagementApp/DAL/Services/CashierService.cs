using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using CashierManagementApp.DAL.Interfaces;
using CashierManagementApp.Model;

namespace CashierManagementApp.DAL.Services
{
    public class CashierService : Interfaces.ICashierService
    {
        private Interfaces.ICashierRepository _repository;

        public CashierService(Interfaces.ICashierRepository repository)
        {
            _repository = repository;
        }


        public string GetAll()
        {
            return _repository.GetAll();
        }

        public string Add()
        {
            return _repository.Add();
        }

        public string Update()
        {
            return _repository.Update();
        }

        public string Delete()
        {
            return _repository.Delete();
        }

        public CashierModel GetById(string id)
        {
            return _repository.GetById(id);
        }
    }
}