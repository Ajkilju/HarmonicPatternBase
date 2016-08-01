using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HarmonicPatternsBase.Models
{
    public class ReactionLvl
    {
        public int Id { get; set; }

        //A,B,C, ponad A
        public string Name { get; set; }

        [InverseProperty("ReactionAfter5Candles")]
        public List<HarmonicPattern> PatternReaction5Candles { get; set; }

        /*
        [InverseProperty("ReactionAfter10Candles")]
        public List<HarmonicPattern> PatternReaction10Candles { get; set; }

        [InverseProperty("ReactionAfter20Candles")]
        public List<HarmonicPattern> PatternReaction20Candles { get; set; }
        */

    }
}
