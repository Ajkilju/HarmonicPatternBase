using HarmonicPatternsBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarmonicPatternBase.Repositories.Abstract
{
    public interface IUsersRepo
    {
        Task<ApplicationUser> GetUserAsync(string Id);
        void UpdateUser(ApplicationUser user);
        void SaveChanges();
    }
}
