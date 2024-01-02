using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashierManagementApp.Model;

namespace CashierManagementApp.DAL.Interfaces
{
    public interface ICashierRepository
    {
        string GetAll();
        string Add();
        string Update();
        string Delete();

        CashierModel GetById(string id);

    }
}
