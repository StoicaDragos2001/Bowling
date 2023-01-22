using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Exceptions
{
    internal class AddedMorePlayersThanDeclaredException : Exception
    {
        public AddedMorePlayersThanDeclaredException(string message) : base(message)
        {

        }
    }
}
