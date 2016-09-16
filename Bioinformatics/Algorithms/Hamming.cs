using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bioinformatics.Algorithms
{
    public static class Hamming
    {

        /// <summary>
        /// Calculates the Hamming Distance between two strings of equal length.
        /// </summary>
        /// <param name="first">The first string</param>
        /// <param name="second">The second string</param>
        /// <exception cref="ArgumentException">Throws if the strings have different lengths</exception>

        public static int Distance(string first, string second)
        {
            if (first.Length != second.Length)
                throw new ArgumentException("Both arguments must have the same length");

            int difference = 0;

            for (int index = 0; index < first.Length; index++)
            {
                if (first[index] != second[index])
                    difference++;
            }

            return difference;
        }

        
    }
}
