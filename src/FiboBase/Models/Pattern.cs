﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarmonicPatternsBase.Models
{
    public class Pattern
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<HarmonicPattern> HarmonicPatterns { get; set; }
        public int AvarageReactionRating { get; set; }
        public int AvaragePrecisionRating { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
    }
}
