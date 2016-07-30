using HarmonicPatternsBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarmonicPatternsBase.Models.HarmonicPatternViewModels
{
    public class HarmonicPatternIndexViewModel
    {
        public List<HarmonicPattern> HarmonicPatterns { get; set; }
        public List<Interval> Intervals { get; set; }
        public List<Pattern> PatternTypes { get; set; }
    }
}
