﻿using HarmonicPatternsBase.Models;
using HarmonicPatternsBase.Models.StatisticModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarmonicPatternsBase.Repositories.Abstract
{
    public interface IHarmonicPatternsRepo
    {
        Task<HarmonicPattern> GetHarmonicPatternAsync(GetHarmonicPatternsMode mode, int? Id);
        Task<List<HarmonicPattern>> GetHarmonicPatternsAsync(
             GetHarmonicPatternsMode mode,
             int? IntervalId = null,
             int? PatternTypeId = null,
             int? InstrumentId = null,
             int? PatternDirectId = null,
             int? HowMany = null);
        Task<Interval> GetIntervalAsync(GetIntervalsMode mode, int? Id);
        Task<List<Interval>> GetIntervalsAsync(GetIntervalsMode mode);
        Task<Pattern> GetPatternTypeAsync(GetPatternTypesMode mode, int? Id);
        Task<List<Pattern>> GetPatternTypesAsync(GetPatternTypesMode mode);
        Task<Instrument> GetInstrumentAsync(GetInstrumentTypesMode mode, int? Id);
        Task<List<Instrument>> GetInstrumentsAsync(GetInstrumentTypesMode mode);
        Task<PatternDirect> GetPatternDirect(GetPatternDirectsMode mode, int? Id);
        Task<List<PatternDirect>> GetPatternDirects(GetPatternDirectsMode mode);
    }
}
