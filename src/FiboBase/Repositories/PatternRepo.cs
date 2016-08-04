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
    public class PatternRepo : IPatternRepo
    {
        private ApplicationDbContext _context;

        public PatternRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Pattern> GetPatternAsync(int? Id)
        {
            if (Id == null)
            {
                return null;
            }

            return await _context.Patterns.AsNoTracking().SingleAsync(h => h.Id == Id);
        }

        public async Task<List<Pattern>> GetPatternsAsync()
        {
            return await _context.Patterns.AsNoTracking().ToListAsync();
        }
    }
}
