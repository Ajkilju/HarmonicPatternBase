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
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [DataType(DataType.Date)]
        public DateTime AddDate { get; set; }
        public string Discription { get; set; }
        public double AvarageReactionRating { get; set; }
        public int NumgerOfReactionRatings { get; set; }
        public double AvaragePrecisionRating { get; set; }
        public int NumberOfPrecisionRatings { get; set; }
        public byte[] Image { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        public int PatternTypeId { get; set; }
        [ForeignKey("PatternTypeId")]
        public Pattern PatternType { get; set; }

        public int IntervalId { get; set; }
        [ForeignKey("IntervalId")]
        public Interval Interval { get; set; }

        public int InstrumentId { get; set; }
        [ForeignKey("InstrumentId")]
        public Instrument Instrument { get; set; }

    }
}
