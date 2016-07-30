using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarmonicPatternsBase.Models.HarmonicPatternViewModels
{
    public class HarmonicPatternCreateViewModel
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }

        public string Instrument { get; set; }
        public string Discription { get; set; }
        public int ReactionRating { get; set; }
        public int PrecisionRating { get; set; }

        public int PatternTypeId { get; set; }
        public int IntervalId { get; set; }

    }
}
