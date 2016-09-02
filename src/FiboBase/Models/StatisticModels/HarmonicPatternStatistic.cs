using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarmonicPatternsBase.Models.StatisticModels
{
    //HarmonicPatternStatistics - klasa, ktora okresla dane dla HarmonicPatternsStatistics
    //HarmonicPatternsStatistics - klasa, w ktorej obliczane są statystyki

    public class HarmonicPatternStatistic
    {
        public int? NumberOfWaves { get; set; }
        public double? ABtoXAratio { get; set; }
        public double? ADtoXAratio { get; set; }
        public double? BCtoABratio { get; set; }
        public double? CDtoBCratio { get; set; }
        public double? CDtoABratio { get; set; }

        public int? ReactionAfter5CandlesId { get; set; }
        public int? ReactionAfter10CandlesId { get; set; }
        public int? ReactionAfter20CandlesId { get; set; }
    }
}
