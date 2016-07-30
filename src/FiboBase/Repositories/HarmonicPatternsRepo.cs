using HarmonicPatternsBase.Data;
using HarmonicPatternsBase.Models;
using HarmonicPatternsBase.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarmonicPatternsBase.Repositories
{
    public enum GetHarmonicPatternsMode
    {
        FullData,
        FullDataAsNoTracking,
        Naked,
        NakedAsNoTracking
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

    public class HarmonicPatternsRepo : IHarmonicPatternsRepo
    {
        private ApplicationDbContext _context;

        public HarmonicPatternsRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<HarmonicPattern>> GetHarmonicPatternsAsync(GetHarmonicPatternsMode mode)
        {
            if (mode == GetHarmonicPatternsMode.FullData)
            {
                return await _context.HarmonicPatterns
                    .Include(h => h.Interval).Include(h => h.PatternType).Include(h => h.User).ToListAsync();
            }
            if (mode == GetHarmonicPatternsMode.FullDataAsNoTracking)
            {
                return await _context.HarmonicPatterns
                    .Include(h => h.Interval).Include(h => h.PatternType).Include(h => h.User).AsNoTracking().ToListAsync();
            }
            if (mode == GetHarmonicPatternsMode.Naked)
            {
                return await _context.HarmonicPatterns.ToListAsync();
            }
            if (mode == GetHarmonicPatternsMode.NakedAsNoTracking)
            {
                return await _context.HarmonicPatterns.AsNoTracking().ToListAsync();
            }

            return await _context.HarmonicPatterns
                .Include(h => h.Interval).Include(h => h.PatternType).Include(h => h.User).ToListAsync();
        }

        public async Task<List<Interval>> GetIntervalsAsync(GetIntervalsMode mode)
        {
            if(mode == GetIntervalsMode.AsNoTracking)
            {
                return await _context.Intervals.AsNoTracking().ToListAsync();
            }

            return await _context.Intervals.ToListAsync();
        }

        public async Task<List<Pattern>> GetPatternTypesAsync(GetPatternTypesMode mode)
        {
            if (mode == GetPatternTypesMode.AsNoTracking)
            {
                return await _context.Patterns.AsNoTracking().ToListAsync();
            }

            return await _context.Patterns.ToListAsync();
        }
    }
}
