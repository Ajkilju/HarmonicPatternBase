﻿using HarmonicPatternsBase.Models.StatisticModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarmonicPatternsBase.Repositories.Abstract
{
    public interface IStatisticsRepo
    {
        Task<List<HarmonicPatternStatistic>> GetHarmonicPatternStatisticisticDataAsync(
            int? IntervalId = null,
            int? PatternTypeId = null,
            int? InstrumentId = null,
            int? PatternDirectId = null,
            DateTime? dateSince = null,
            DateTime? dateTo = null,
            DateTime? addDateSince = null,
            DateTime? addDateTo = null);

        List<int> GetReactionIds();
    }
}
