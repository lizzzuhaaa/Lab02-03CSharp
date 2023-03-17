using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01Sydorova
{
    internal class ValidationPastBirth : Exception
    {
        private string _message;

        public ValidationPastBirth(string message)
        {
            this._message = message;
        }
        public ValidationPastBirth(string message, DateTime date) : this("Incorrect age: this person is older then 135 y.o.")
        {
        }

        public override string Message
        {
            get { return _message; }
        }
    }
}
