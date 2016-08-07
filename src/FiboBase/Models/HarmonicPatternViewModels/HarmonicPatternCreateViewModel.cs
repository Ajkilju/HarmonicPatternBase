using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarmonicPatternsBase.Models.HarmonicPatternViewModels
{
    public class HarmonicPatternCreateViewModel
    {
        public string Discription { get; set; }
        public int ReactionRating { get; set; }
        public int PrecisionRating { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string DateNow { get; set; }
        public string TimeNow { get; set; }

        public int NumberOfWaves { get; set; }
        public double ABtoXAratio { get; set; }
        public double ADtoXAratio { get; set; }
        public double BCtoABratio { get; set; }
        public double CDtoBCratio { get; set; }
        public double CDtoABratio { get; set; }

        public int PatternTypeId { get; set; }
        public int IntervalId { get; set; }
        public int InstrumentId { get; set; }
        public int PatternDirectId { get; set; }
        public int ReactionAfter5CandlesId { get; set; }
        public int ReactionAfter10CandlesId { get; set; }
        public int ReactionAfter20CandlesId { get; set; }

        public SelectList IntervalList { get; set; }
        public SelectList PatternTypeList { get; set; }
        public SelectList InstrumentList { get; set; }
        public SelectList PatternDirectList { get; set; }
        public SelectList ReactionLvlsList { get; set; }
        public SelectList WaveRatioList { get; set; }
        public SelectList NumberOfWavesList { get; set; }
        
    }
}
