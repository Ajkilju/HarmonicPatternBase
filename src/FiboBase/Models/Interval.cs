﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarmonicPatternsBase.Models
{
    public class Interval 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<HarmonicPattern> HarmonicPatterns { get; set; }
    }
}
