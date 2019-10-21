using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaraKhezriCrudTest.Models
{
    public class ThisEmailAlreadyExistsException : Exception
    {
        public ThisEmailAlreadyExistsException()
        {
        }
        public ThisEmailAlreadyExistsException(string message) : base(message)
        {
        }

        public ThisEmailAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
