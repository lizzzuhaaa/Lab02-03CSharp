using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01Sydorova
{
    internal class ValidationFutureBirth : Exception
    {
        private string _message;

        public ValidationFutureBirth(string message)
        {
            this._message = message;
        }
        public ValidationFutureBirth(string message, DateTime date) : this("Incorrect age: this person doesn`t exist")
        {
        }

        public override string Message
        {
            get { return _message; }
        }
    }
}
