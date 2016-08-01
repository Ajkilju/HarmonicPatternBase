using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarmonicPatternsBase.Models
{
    public class Pattern
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<HarmonicPattern> HarmonicPatterns { get; set; }

        public string Description { get; set; }
        public byte[] Image { get; set; }
        public string ImageString { get; set; }

        public int NumberOfWaves { get; set; }
        public double ABtoXAratio { get; set; }
        public double ADtoXAratio { get; set; }
        public double BCtoABratio { get; set; }
        public double CDtoBCratio { get; set; }
        public double CDtoABratio { get; set; }
    }
}
