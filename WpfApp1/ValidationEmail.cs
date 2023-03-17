using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01Sydorova
{
    internal class ValidationEmail: Exception
    {
        private string _message; 

        public ValidationEmail(string message) 
        {
            this._message = message;
        }
        public ValidationEmail(string message, string email) : this("Your email is invalid format")
        {
        }

        public override string Message 
        {
            get { return _message; }
        }
    }
}
