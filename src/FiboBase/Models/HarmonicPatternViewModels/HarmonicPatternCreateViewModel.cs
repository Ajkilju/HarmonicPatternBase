using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarmonicPatternsBase.Models.HarmonicPatternViewModels
{
    public class HarmonicPatternCreateViewModel
    {
        public HarmonicPattern HarmonicPattern { get; set; }

        public DateTime Date { get; set; }
        public DateTime Time { get; set; }

        public SelectList IntervalList { get; set; }
        public SelectList PatternTypeList { get; set; }
        public SelectList InstrumentList { get; set; }
        public SelectList PatternDirectList { get; set; }
        public SelectList ReactionLvlsList { get; set; }
        public SelectList WaveRatioList { get; set; }
        public SelectList NumberOfWavesList { get; set; }

        public string ABtoXAratio { get; set; }
        public string ADtoXAratio { get; set; }
        public string BCtoABratio { get; set; }
        public string CDtoBCratio { get; set; }
        public string CDtoABratio { get; set; }

    }
}
