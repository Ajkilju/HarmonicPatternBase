using HarmonicPatternsBase.Data;
using HarmonicPatternsBase.Models;
using HarmonicPatternsBase.Models.StatisticModels;
using HarmonicPatternsBase.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarmonicPatternsBase.Repositories
{
    public class StatisticsRepo : IStatisticsRepo
    {
        private ApplicationDbContext _context;

        public StatisticsRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<HarmonicPatternStatistic>> GetHarmonicPatternStatisticisticDataAsync(
            int? IntervalId = null, 
            int? PatternTypeId = null, 
            int? InstrumentId = null,
            int? PatternDirectId = null,
            int? HowMany = null)
        {
            var data = (IQueryable<HarmonicPattern>)_context.HarmonicPatterns
                .Include(h => h.Interval)
                .Include(h => h.PatternType)
                .Include(h => h.Instrument)
                .Include(h => h.User)
                .Include(h => h.PatternDirect)
                .Include(h => h.ReactionAfter5Candles)
                .Include(h => h.ReactionAfter10Candles)
                .Include(h => h.ReactionAfter20Candles);

            if (IntervalId != null)
            {
                data = data.Where(h => h.IntervalId == IntervalId);
            }

            if (PatternTypeId != null)
            {
                data = data.Where(h => h.PatternTypeId == PatternTypeId);
            }

            if (InstrumentId != null)
            {
                data = data.Where(h => h.InstrumentId == InstrumentId);
            }

            if(PatternDirectId != null)
            {
                data = data.Where(h => h.PatternDirectId == PatternDirectId);
            }

            if (HowMany != null)
            {
                data = data.Take((int)HowMany);
            }

            var statisticsData = data.Select(h => new HarmonicPatternStatistic
            {
                ABtoXAratio = h.ABtoXAratio,
                ADtoXAratio = h.ADtoXAratio,
                BCtoABratio = h.BCtoABratio,
                CDtoABratio = h.CDtoABratio,
                CDtoBCratio = h.CDtoBCratio,
                NumberOfWaves = h.NumberOfWaves,
                ReactionAfter5CandlesId = h.ReactionAfter5CandlesId,
                ReactionAfter10CandlesId = h.ReactionAfter10CandlesId,
                ReactionAfter20CandlesId = h.ReactionAfter20CandlesId,
            });

            return await statisticsData.ToListAsync();
        }
    }
}
