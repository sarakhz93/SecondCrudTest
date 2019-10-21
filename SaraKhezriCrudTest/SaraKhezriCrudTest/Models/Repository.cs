using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaraKhezriCrudTest.Models
{
    public class Repository
    {
        readonly Dbctx _dbctx;
        public Repository(Dbctx dbctx)
        {
            _dbctx = dbctx;
        }

        public Customer FindById(int id)
        {
            var expectedCustomer = _dbctx.Customers
                                         .SingleOrDefault(customer => customer.Id == id);

            if (expectedCustomer == null)
                throw new CustomerNotFoundException();

            return expectedCustomer;
        }

        public void Save(Customer customer)
        {
            _dbctx.Customers.Add(customer);
            _dbctx.SaveChanges();
        }

        public void Update()
        => _dbctx.SaveChanges();

        public void Delete(Customer customer)
        {
            _dbctx.Customers.Remove(customer);
            _dbctx.SaveChanges();
        }

        public bool DoesEmailExist(string email, int? toBeUpdatedCustomerId)
        {
            var expectedCustomer = _dbctx.Customers
                                         .FirstOrDefault(customer => customer.Email == email 
                                                                  && customer.Id != toBeUpdatedCustomerId);

            return expectedCustomer == null
                ? false
                : true;
        }

        public bool DoesCustomerExist(string firstName, string lastName, string dateOfBirth, int? toBeUpdatedCustomerId)
        {
            var expectedCustomer = _dbctx.Customers
                                         .FirstOrDefault(customer => customer.FirstName == firstName
                                                                  && customer.LastName == lastName
                                                                  && customer.DateOfBirth == dateOfBirth
                                                                  && customer.Id != toBeUpdatedCustomerId);

            return expectedCustomer == null
                ? false
                : true;
        }
    }
}
