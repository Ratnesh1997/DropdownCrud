using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudR.Models;
using CrudR.Repo.Contract;
using CrudR.Data_Access;
namespace CrudR.Repo.Services
{
    public class CustomerService : ICustomer
    {
        private readonly DatabaseConn _Conn;
        public CustomerService(DatabaseConn Conn) { _Conn = Conn; }

        public bool Delete(int id)
        {
            var deleteData = _Conn.Customers.SingleOrDefault(dataid => dataid.Id == id);
            _Conn.Customers.Remove(deleteData);
            _Conn.SaveChanges();
            return true;
        }

        public List<Customer> GetAllDetails()
        {
             
            return _Conn.Customers.ToList();
        }

        public Customer GetById(int id)
        {
            
            return _Conn.Customers.SingleOrDefault(dataid => dataid.Id == id);

        }

        public Customer InsertCustomer(Customer data)
        {
             _Conn.Customers.Add(data);
            _Conn.SaveChanges();
            return data;

        }

        public Customer Update(Customer data1)
        {
            _Conn.Customers.Update(data1);
            _Conn.SaveChanges();
            return data1;
        }
    }
}
