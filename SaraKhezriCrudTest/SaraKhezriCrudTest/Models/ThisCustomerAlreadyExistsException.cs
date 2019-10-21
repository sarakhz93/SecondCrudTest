using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaraKhezriCrudTest.Models
{
    public class ThisCustomerAlreadyExistsException : Exception
    {
        public ThisCustomerAlreadyExistsException()
        {
        }
        public ThisCustomerAlreadyExistsException(string message) : base(message)
        {
        }

        public ThisCustomerAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
