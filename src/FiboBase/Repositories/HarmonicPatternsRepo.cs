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

    public enum GetIntervalsMode
    {
        AsNoTracking,
        Tracking
    }

    public enum GetPatternTypesMode
    {
        AsNoTracking,
        Tracking
    }

    public enum GetInstrumentTypesMode
    {
        AsNoTracking,
        Tracking
    }

    public enum GetPatternDirectsMode
    {
        AsNoTracking,
        Tracking
    }

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
                .Include(h => h.ReactionAfter20Candles);

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

        public async Task<Interval> GetIntervalAsync(GetIntervalsMode mode, int? Id)
        {
            if(Id == null)
            {
                return null;
            }

            if(mode == GetIntervalsMode.AsNoTracking)
            {
                return await _context.Intervals.AsNoTracking().SingleAsync(h => h.Id == Id);
            }

            return await _context.Intervals.SingleAsync(h => h.Id == Id);
        }

        public async Task<List<Interval>> GetIntervalsAsync(GetIntervalsMode mode)
        {
            if(mode == GetIntervalsMode.AsNoTracking)
            {
                return await _context.Intervals.AsNoTracking().ToListAsync();
            }

            return await _context.Intervals.ToListAsync();
        }

        public async Task<Pattern> GetPatternTypeAsync(GetPatternTypesMode mode, int? Id)
        {
            if (Id == null)
            {
                return null;
            }

            if (mode == GetPatternTypesMode.AsNoTracking)
            {
                return await _context.Patterns.AsNoTracking().SingleAsync(h => h.Id == Id);
            }

            return await _context.Patterns.SingleAsync(h => h.Id == Id);
        }

        public async Task<List<Pattern>> GetPatternTypesAsync(GetPatternTypesMode mode)
        {
            if (mode == GetPatternTypesMode.AsNoTracking)
            {
                return await _context.Patterns.AsNoTracking().ToListAsync();
            }

            return await _context.Patterns.ToListAsync();
        }

        public async Task<Instrument> GetInstrumentAsync(GetInstrumentTypesMode mode, int? Id)
        {
            if (Id == null)
            {
                return null;
            }

            if (mode == GetInstrumentTypesMode.AsNoTracking)
            {
                return await _context.Instruments.AsNoTracking().SingleAsync(h => h.Id == Id);
            }

            return await _context.Instruments.SingleAsync(h => h.Id == Id);
        }

        public async Task<List<Instrument>> GetInstrumentsAsync(GetInstrumentTypesMode mode)
        {
            if (mode == GetInstrumentTypesMode.AsNoTracking)
            {
                return await _context.Instruments.AsNoTracking().ToListAsync();
            }

            return await _context.Instruments.ToListAsync();
        }

        public async Task<PatternDirect> GetPatternDirect(GetPatternDirectsMode mode, int? Id)
        {
            if (Id == null)
            {
                return null;
            }

            if (mode ==  GetPatternDirectsMode.AsNoTracking)
            {
                return await _context.PatternDirects.AsNoTracking().SingleAsync(h => h.Id == Id);
            }

            return await _context.PatternDirects.SingleAsync(h => h.Id == Id);
        }

        public async Task<List<PatternDirect>> GetPatternDirects(GetPatternDirectsMode mode)
        {
            if (mode == GetPatternDirectsMode.AsNoTracking)
            {
                return await _context.PatternDirects.AsNoTracking().ToListAsync();
            }

            return await _context.PatternDirects.ToListAsync();
        }
    }
}
