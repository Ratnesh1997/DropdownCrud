using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudR.Models;
namespace CrudR.Repo.Contract
{
     public interface ICustomer
    {
         List<Customer> GetAllDetails();
        Customer InsertCustomer(Customer data);
         bool Delete(int id);
         Customer GetById(int id);
         Customer Update(Customer data1);
    }
}
