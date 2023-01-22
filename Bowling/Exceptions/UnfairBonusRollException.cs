using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Exceptions
{
    internal class UnfairBonusRollException : Exception
    {
        public UnfairBonusRollException(string message) : base(message)
        {

        }
    }
}
