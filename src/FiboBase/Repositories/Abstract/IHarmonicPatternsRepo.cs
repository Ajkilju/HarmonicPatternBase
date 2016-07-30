using HarmonicPatternsBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarmonicPatternsBase.Repositories.Abstract
{
    public interface IHarmonicPatternsRepo
    {
        Task<List<HarmonicPattern>> GetHarmonicPatternsAsync(GetHarmonicPatternsMode mode);
        Task<List<Interval>> GetIntervalsAsync(GetIntervalsMode mode);
        Task<List<Pattern>> GetPatternTypesAsync(GetPatternTypesMode mode);
    }
}
