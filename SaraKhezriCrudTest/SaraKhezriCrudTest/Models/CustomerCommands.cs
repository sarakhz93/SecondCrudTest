using System;
using System.Collections.Generic;
using System.Text;

namespace SaraKhezriCrudTest.Models
{
    public class CustomerCommands
    {
        readonly Repository _repository;
        public CustomerCommands(Repository repository)
        {
            _repository = repository;
        }
        public void AddCustomer_Execute(Customer customer)
        {
            if (_repository.DoesEmailExist(customer.Email, null))
                throw new ThisEmailAlreadyExistsException("This Email Already Exists");

            if (_repository.DoesCustomerExist(customer.FirstName, customer.LastName, customer.DateOfBirth, null))
                throw new ThisCustomerAlreadyExistsException("This Customer Already Exists");

            _repository.Save(customer);
        }

        public void EditCustomer_Execute(int oldCustomerId, Customer newCustomer)
        {
            if (_repository.DoesEmailExist(newCustomer.Email, oldCustomerId))
                throw new ThisEmailAlreadyExistsException("This Email Already Exists");

            if (_repository.DoesCustomerExist(newCustomer.FirstName, newCustomer.LastName, newCustomer.DateOfBirth, oldCustomerId))
                throw new ThisCustomerAlreadyExistsException("This Customer Already Exists");

            var customerToBeUpdated = _repository.FindById(oldCustomerId);

            customerToBeUpdated.FirstName = newCustomer.FirstName;
            customerToBeUpdated.LastName = newCustomer.LastName;
            customerToBeUpdated.DateOfBirth = newCustomer.DateOfBirth;
            customerToBeUpdated.PhoneNumber = newCustomer.PhoneNumber;
            customerToBeUpdated.Email = newCustomer.Email;
            customerToBeUpdated.BankAccountNumber = newCustomer.BankAccountNumber;

            _repository.Update();
        }

        public void DeleteCustomer_Execute(int customerId)
        {
            var customer = _repository.FindById(customerId);
            _repository.Delete(customer);
        }
    }
}
