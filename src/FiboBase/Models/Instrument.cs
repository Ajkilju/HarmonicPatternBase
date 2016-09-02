using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarmonicPatternsBase.Models
{
    public class Instrument
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public List<HarmonicPattern> HarmonicPatterns { get; set; }
    }

    public class InstrumentCategory
    {
        public List<Instrument> Instruments { get; set; }
        public string Name { get; set; }
    }
}
