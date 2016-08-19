using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bioinformatics;
using System.IO;

namespace BioTest
{
    public static class Load
    {
        public static DnaStrand LoadStrand(string filePath)
        {
            string rawText = File.ReadAllText(filePath);
            return new DnaStrand(rawText);
        }
    }
}
