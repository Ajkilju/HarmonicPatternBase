using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarmonicPatternsBase.Models.StatisticModels
{
    //klasa zawiera statystyki konkretnej reakcji

    public class ReactionStatistic
    {
        public int ReactionId { get; set; }
        public IEnumerable<HarmonicPatternStatistic> Data { get; set; }
        public int ReactionCon { get; set; }
        public double PercentOfAllData { get; set; } 
    }
}
