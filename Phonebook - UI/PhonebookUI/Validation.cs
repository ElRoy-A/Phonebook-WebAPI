using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonebookUI
{
    internal class Validation
    {
        public static bool IsIdValid(string stringInput)
        {

            if (String.IsNullOrEmpty(stringInput))
            {
                return false;
            }

            foreach (char c in stringInput)
            {
                if (!Char.IsDigit(c))
                    return false;
            }

            return true;
        }
    }
}
