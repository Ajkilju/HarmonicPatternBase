using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HarmonicPatternsBase.Models
{
    public class HarmonicPattern
    {
        public int Id { get; set; }
        public string Discription { get; set; }
        public byte[] Image { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [DataType(DataType.Date)]
        public DateTime AddDate { get; set; }

        public int? NumberOfWaves { get; set; }
        public double? ABtoXAratio { get; set; }
        public double? ADtoXAratio { get; set; }
        public double? BCtoABratio { get; set; }
        public double? CDtoBCratio { get; set; }
        public double? CDtoABratio { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        public int? PatternTypeId { get; set; }
        [ForeignKey("PatternTypeId")]
        public Pattern PatternType { get; set; }

        public int? IntervalId { get; set; }
        [ForeignKey("IntervalId")]
        public Interval Interval { get; set; }

        public int? InstrumentId { get; set; }
        [ForeignKey("InstrumentId")]
        public Instrument Instrument { get; set; }

        public int? PatternDirectId { get; set; }
        [ForeignKey("PatternDirectId")]
        public PatternDirect PatternDirect { get; set; }

        public int? ReactionAfter5CandlesId { get; set; }
        [ForeignKey("ReactionAfter5CandlesId")]
        public ReactionLvl ReactionAfter5Candles { get; set; }
      
        public int? ReactionAfter10CandlesId { get; set; }
        [ForeignKey("ReactionAfter10CandlesId")]
        public ReactionLvl ReactionAfter10Candles { get; set; }

        public int? ReactionAfter20CandlesId { get; set; }
        [ForeignKey("ReactionAfter20CandlesId")]
        public ReactionLvl ReactionAfter20Candles { get; set; }
        

    }
}
