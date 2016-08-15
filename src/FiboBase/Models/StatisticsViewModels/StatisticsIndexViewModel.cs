﻿using HarmonicPatternsBase.Models.StatisticModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarmonicPatternsBase.Models.StatisticsViewModels
{
    public class StatisticsIndexViewModel
    {
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

    }
}