using HarmonicPatternsBase.Models;
using HarmonicPatternsBase.Models.StatisticModels;
using Sakura.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarmonicPatternsBase.Models.HarmonicPatternViewModels
{
    public class HarmonicPatternIndexViewModel
    {
        public IPagedList<HarmonicPattern> HarmonicPatterns { get; set; }
        public List<Interval> Intervals { get; set; }
        public List<Pattern> PatternTypes { get; set; }
        public List<Instrument> Instruments { get; set; }
        public List<PatternDirect> PatternDirects { get; set; }

        public Pattern SelectedPattern { get; set; }
        public Interval SelectedInterval { get; set; }
        public Instrument SelectedInstrument { get; set; }
        public PatternDirect SelectedDirect { get; set; }

        public int? SelectedPatternId { get; set; }
        public int? SelectedIntervalId { get; set; }
        public int? SelectedInstrumentId { get; set; }
        public int? SelectedDirectId { get; set; }
        
        public HarmonicPatternsStatistic Statistics { get; set; }

        public List<ReactionLvl> ReactionLevels { get; set; }

        public string DateSinceString { get; set; }
        public string DateToString { get; set; }
        public string AddDateSinceString { get; set; }
        public string AddDateToString { get; set; }

        public DateTime? DateSince { get; set; }
        public DateTime? DateTo { get; set; }
        public DateTime? AddDateSince { get; set; }
        public DateTime? AddDateTo { get; set; }

        public int SortOrder { get; set; }
        public List<string> SortOrdersList { get; set; }
    }
}
