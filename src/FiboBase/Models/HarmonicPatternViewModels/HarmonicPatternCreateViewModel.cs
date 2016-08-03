using Microsoft.AspNetCore.Mvc.Rendering;
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

        public string Discription { get; set; }
        public int ReactionRating { get; set; }
        public int PrecisionRating { get; set; }

        public int PatternTypeId { get; set; }
        public int IntervalId { get; set; }
        public int InstrumentId { get; set; }
        public int PatternDirectId { get; set; }

        public SelectList DayList { get; set; }
        public SelectList MonthList { get; set; }
        public SelectList YearList { get; set; }
        public SelectList HourList { get; set; }
        public SelectList MinuteList { get; set; }
        public SelectList IntervalList { get; set; }
        public SelectList PatternTypeList { get; set; }
        public SelectList InstrumentList { get; set; }
        public SelectList PatternDirectList { get; set; }
    }
}
