using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Exceptions
{
    internal class NumberOfFramesOutOfRangeException : Exception
    {
        public NumberOfFramesOutOfRangeException(string message) : base(message)
        {

        }
    }
}
