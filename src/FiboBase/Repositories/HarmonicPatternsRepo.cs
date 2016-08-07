using HarmonicPatternsBase.Data;
using HarmonicPatternsBase.Models;
using HarmonicPatternsBase.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using HarmonicPatternsBase.Models.StatisticModels;

namespace HarmonicPatternsBase.Repositories
{
    public enum GetHarmonicPatternsMode
    {
        AsNoTracking,
        Tracking
    };

    public class HarmonicPatternsRepo : IHarmonicPatternsRepo
    {
        private ApplicationDbContext _context;

        public HarmonicPatternsRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<HarmonicPattern> GetHarmonicPatternAsync(GetHarmonicPatternsMode mode, int? Id)
        {
            if (Id == null)
            {
                return null;
            }

            if (mode == GetHarmonicPatternsMode.AsNoTracking)
            {
                return await _context.HarmonicPatterns
                    .Include(h => h.Interval)
                    .Include(h => h.PatternType)
                    .Include(h => h.Instrument)
                    .Include(h => h.User)
                    .Include(h => h.PatternDirect)
                    .Include(h => h.ReactionAfter5Candles)
                    .Include(h => h.ReactionAfter10Candles)
                    .Include(h => h.ReactionAfter20Candles)
                    .AsNoTracking()
                    .SingleAsync(h => h.Id == Id);
            }

            return await _context.HarmonicPatterns
                    .Include(h => h.Interval)
                    .Include(h => h.PatternType)
                    .Include(h => h.Instrument)
                    .Include(h => h.User)
                    .Include(h => h.PatternDirect)
                    .Include(h => h.ReactionAfter5Candles)
                    .Include(h => h.ReactionAfter10Candles)
                    .Include(h => h.ReactionAfter20Candles)
                    .SingleAsync(h => h.Id == Id);
        }

        public async Task<List<HarmonicPattern>> GetHarmonicPatternsAsync (
            GetHarmonicPatternsMode mode, 
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
                .Include(h => h.ReactionAfter20Candles)
                .OrderByDescending(h => h.Date);

            if (IntervalId != null)
            {
                data = data.Where(h => h.IntervalId == IntervalId);
            }

            if(PatternTypeId != null)
            {
                data = data.Where(h => h.PatternTypeId == PatternTypeId);
            }

            if(InstrumentId != null)
            {
                data = data.Where(h => h.InstrumentId == InstrumentId);
            }

            if(PatternDirectId != null)
            {
                data = data.Where(h => h.PatternDirectId == PatternDirectId);
            }

            if(HowMany != null)
            {
                data = data.Take((int)HowMany);
            }

            if (mode == GetHarmonicPatternsMode.AsNoTracking)
            {
                data = data.AsNoTracking();
            }

            return await data.ToListAsync();
        }

        public IQueryable<HarmonicPattern> GetHarmonicPatternsQuery(
            GetHarmonicPatternsMode mode,
            int SortOrder,
            int? IntervalId = null,
            int? PatternTypeId = null,
            int? InstrumentId = null,
            int? PatternDirectId = null,
            DateTime? dateSince = null,
            DateTime? dateTo = null,
            DateTime? addDateSince = null,
            DateTime? addDateTo = null)
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

            if (PatternDirectId != null)
            {
                data = data.Where(h => h.PatternDirectId == PatternDirectId);
            }

            if(dateSince != null)
            {
                data = data.Where(h => h.Date >= dateSince);
            }

            if (dateTo != null)
            {
                data = data.Where(h => h.Date <= dateTo);
            }

            if (addDateSince != null)
            {
                data = data.Where(h => h.AddDate >= addDateSince);
            }

            if (addDateTo != null)
            {
                data = data.Where(h => h.AddDate <= addDateTo);
            }

            switch(SortOrder)
            {
                case 0:
                    data = data.OrderByDescending(h => h.Date);
                    break;
                case 1:
                    data = data.OrderBy(h => h.Date);
                    break;
                case 2:
                    data = data.OrderByDescending(h => h.AddDate);
                    break;
                case 3:
                    data = data.OrderBy(h => h.AddDate);
                    break;
                default:
                    data = data.OrderByDescending(h => h.Date);
                    break;
            }

            if (mode == GetHarmonicPatternsMode.AsNoTracking)
            {
                data = data.AsNoTracking();
            }

            return data;
        }

        public async Task<Interval> GetIntervalAsync(int? Id)
        {
            if(Id == null)
            {
                return null;
            }

            return await _context.Intervals.SingleAsync(h => h.Id == Id);
        }

        public async Task<List<Interval>> GetIntervalsAsync()
        {
            return await _context.Intervals.ToListAsync();
        }

        public async Task<Pattern> GetPatternTypeAsync(int? Id)
        {
            if (Id == null)
            {
                return null;
            }

            return await _context.Patterns.SingleAsync(h => h.Id == Id);
        }

        public async Task<List<Pattern>> GetPatternTypesAsync()
        {
            return await _context.Patterns.ToListAsync();
        }

        public async Task<Instrument> GetInstrumentAsync(int? Id)
        {
            if (Id == null)
            {
                return null;
            }

            return await _context.Instruments.SingleAsync(h => h.Id == Id);
        }

        public async Task<List<Instrument>> GetInstrumentsAsync()
        {
            return await _context.Instruments.ToListAsync();
        }

        public async Task<PatternDirect> GetPatternDirectAsync(int? Id)
        {
            if (Id == null)
            {
                return null;
            }

            return await _context.PatternDirects.SingleAsync(h => h.Id == Id);
        }

        public async Task<List<PatternDirect>> GetPatternDirectsAsync()
        {
            return await _context.PatternDirects.ToListAsync();
        }

        public async Task<List<ReactionLvl>> GetReactionLvlsAsync()
        {
            return await _context.ReactionLvls.ToListAsync();
        }
    }
}
