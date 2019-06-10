using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
    public class ValidateException : Exception
    {
        public ValidateException()
        {
        }

        public ValidateException(string message) : base(message)
        {
        }
    }
}
