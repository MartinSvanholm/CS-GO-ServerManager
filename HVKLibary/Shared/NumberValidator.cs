using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVKLibary
{
    public static class NumberValidator
    {
        public static int ValidateNumberBy(int value, Func<int, bool> validationPredicate)
        {
            if (validationPredicate(value))
            {
                return value;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(value), "skal være større end 0");
            }
        }
    }
}