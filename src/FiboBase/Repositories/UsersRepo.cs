using HarmonicPatternBase.Repositories.Abstract;
using HarmonicPatternsBase.Data;
using HarmonicPatternsBase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarmonicPatternBase.Repositories
{
    public class UsersRepo : IUsersRepo
    {
        private ApplicationDbContext _context;

        public UsersRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApplicationUser> GetUserAsync(string Id)
        {
            return await _context.Users.SingleAsync(h => h.Id == Id);
        }
    }
}
