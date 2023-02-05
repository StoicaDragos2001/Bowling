using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Exceptions
{
    internal class ShotIndexOutOfBoundsException : Exception
    {
        public ShotIndexOutOfBoundsException(string message) : base(message) { }
    }
}
