using Sakura.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarmonicPatternsBase.Models.ManageViewModels
{
    public class MyPatternsViewModel
    {
        public IPagedList<HarmonicPattern> HarmonicPatterns { get; set; }
    }
}
