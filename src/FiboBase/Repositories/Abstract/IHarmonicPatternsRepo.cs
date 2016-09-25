using HarmonicPatternsBase.Models;
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

        IQueryable<HarmonicPattern> GetHarmonicPatternsQuery(
            GetHarmonicPatternsMode mode,
            int SortOrder,
            int? IntervalId = null,
            int? PatternTypeId = null,
            int? InstrumentId = null,
            int? PatternDirectId = null,
            DateTime? dateSince = null,
            DateTime? dateTo = null,
            DateTime? addDateSince = null,
            DateTime? addDateTo = null,
            string userId = null);

        void AddHarmonicPattern(HarmonicPattern hp);
        void UpdateHarmonicPattern(HarmonicPattern hp);
        void RemoveHarmonicPattern(HarmonicPattern hp);
        Task<int> SaveChangesAsync();
        int SaveChanges();

        Task<Interval> GetIntervalAsync(int? Id);
        Task<List<Interval>> GetIntervalsAsync();
        Task<Pattern> GetPatternTypeAsync(int? Id);
        Task<List<Pattern>> GetPatternTypesAsync();
        Task<Instrument> GetInstrumentAsync(int? Id);
        Task<List<Instrument>> GetInstrumentsAsync();
        Task<PatternDirect> GetPatternDirectAsync(int? Id);
        Task<List<PatternDirect>> GetPatternDirectsAsync();
        Task<List<ReactionLvl>> GetReactionLvlsAsync();
    }
}
