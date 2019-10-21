using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaraKhezriCrudTest.Models
{
    public class CustomerQueries
    {
        readonly Dbctx _dbctx;
        public CustomerQueries(Dbctx dbctx)
        {
            _dbctx = dbctx;
        }

        public List<Customer> FindAllCustomers_Execute()
        => _dbctx.Customers
                 .ToList();

        public Customer FindCustomerById_Execute(int id)
        {
            var expectedCustomer = _dbctx.Customers
                                         .SingleOrDefault(customer => customer.Id == id);
            if (expectedCustomer == null)
                throw new CustomerNotFoundException();

            return expectedCustomer;
        }  
    }
}
