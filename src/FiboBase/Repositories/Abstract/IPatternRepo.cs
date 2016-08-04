using HarmonicPatternsBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarmonicPatternsBase.Repositories.Abstract
{
     public interface IPatternRepo
    {
        Task<Pattern> GetPatternAsync(int? Id);
        Task<List<Pattern>> GetPatternsAsync();
    }
}
