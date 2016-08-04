using HarmonicPatternsBase.Models.StatisticModels;
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
            int? HowMany = null);
    }
}
