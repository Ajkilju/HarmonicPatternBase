using HarmonicPatternsBase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarmonicPatternsBase.Data
{
    public class SeedData
    {
        public static void IntervalsInit(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Intervals.Any())
                {
                    return;   // DB has been seeded
                }

                context.Intervals.AddRange
                (
                    new Interval
                    {
                        AvaragePrecisionRating = 0,
                        AvarageReactionRating = 0,
                        HarmonicPatterns = new List<HarmonicPattern>(),
                        Value = "1m"
                    },
                    new Interval
                    {
                        AvaragePrecisionRating = 0,
                        AvarageReactionRating = 0,
                        HarmonicPatterns = new List<HarmonicPattern>(),
                        Value = "5m"
                    },
                    new Interval
                    {
                        AvaragePrecisionRating = 0,
                        AvarageReactionRating = 0,
                        HarmonicPatterns = new List<HarmonicPattern>(),
                        Value = "15m"
                    },
                    new Interval
                    {
                        AvaragePrecisionRating = 0,
                        AvarageReactionRating = 0,
                        HarmonicPatterns = new List<HarmonicPattern>(),
                        Value = "30m"
                    },
                    new Interval
                    {
                        AvaragePrecisionRating = 0,
                        AvarageReactionRating = 0,
                        HarmonicPatterns = new List<HarmonicPattern>(),
                        Value = "1h"
                    },
                    new Interval
                    {
                        AvaragePrecisionRating = 0,
                        AvarageReactionRating = 0,
                        HarmonicPatterns = new List<HarmonicPattern>(),
                        Value = "4h"
                    },
                    new Interval
                    {
                        AvaragePrecisionRating = 0,
                        AvarageReactionRating = 0,
                        HarmonicPatterns = new List<HarmonicPattern>(),
                        Value = "1d"
                    },
                    new Interval
                    {
                        AvaragePrecisionRating = 0,
                        AvarageReactionRating = 0,
                        HarmonicPatterns = new List<HarmonicPattern>(),
                        Value = "1w"
                    },
                    new Interval
                    {
                        AvaragePrecisionRating = 0,
                        AvarageReactionRating = 0,
                        HarmonicPatterns = new List<HarmonicPattern>(),
                        Value = "mn"
                    }
                );

                context.SaveChanges();
            }
        }

        public static void PatternsInit(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Patterns.Any())
                {
                    return;   // DB has been seeded
                }

                context.Patterns.AddRange
                (
                    new Pattern
                    {
                        AvaragePrecisionRating = 0,
                        AvarageReactionRating = 0,
                        Description = "Formacja motyla",
                        HarmonicPatterns = new List<HarmonicPattern>(),
                        Image = new byte[1],
                        Name = "Motyl"
                    },
                    new Pattern
                    {
                        AvaragePrecisionRating = 0,
                        AvarageReactionRating = 0,
                        Description = "Korekta prosta",
                        HarmonicPatterns = new List<HarmonicPattern>(),
                        Image = new byte[1],
                        Name = "ABCD"
                    },
                    new Pattern
                    {
                        AvaragePrecisionRating = 0,
                        AvarageReactionRating = 0,
                        Description = "Formacja gartleya",
                        HarmonicPatterns = new List<HarmonicPattern>(),
                        Image = new byte[1],
                        Name = "Gartley"
                    },
                    new Pattern
                    {
                        AvaragePrecisionRating = 0,
                        AvarageReactionRating = 0,
                        Description = "Inne formache harmoniczne",
                        HarmonicPatterns = new List<HarmonicPattern>(),
                        Image = new byte[1],
                        Name = "Inna"
                    }
                );
                context.SaveChanges();
            }
        }

        //public static void HarmonicPatternInit(IServiceProvider serviceProvider)
        //{
        //    using (var context = new ApplicationDbContext(
        //        serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
        //    {
        //        if (context.HarmonicPatterns.Any())
        //        {
        //            return;   // DB has been seeded
        //        }

        //        context.Intervals.AddRange
        //        (
        //            new Interval
        //            {
        //                AvaragePrecisionRating = 0,
        //                AvarageReactionRating = 0,
        //                HarmonicPatterns = new List<HarmonicPattern>(),
        //                Value = "1m"
        //            },
        //            new Interval
        //            {
        //                AvaragePrecisionRating = 0,
        //                AvarageReactionRating = 0,
        //                HarmonicPatterns = new List<HarmonicPattern>(),
        //                Value = "5m"
        //            },
        //            new Interval
        //            {
        //                AvaragePrecisionRating = 0,
        //                AvarageReactionRating = 0,
        //                HarmonicPatterns = new List<HarmonicPattern>(),
        //                Value = "15m"
        //            },
        //            new Interval
        //            {
        //                AvaragePrecisionRating = 0,
        //                AvarageReactionRating = 0,
        //                HarmonicPatterns = new List<HarmonicPattern>(),
        //                Value = "30m"
        //            },
        //            new Interval
        //            {
        //                AvaragePrecisionRating = 0,
        //                AvarageReactionRating = 0,
        //                HarmonicPatterns = new List<HarmonicPattern>(),
        //                Value = "1h"
        //            },
        //            new Interval
        //            {
        //                AvaragePrecisionRating = 0,
        //                AvarageReactionRating = 0,
        //                HarmonicPatterns = new List<HarmonicPattern>(),
        //                Value = "4h"
        //            },
        //            new Interval
        //            {
        //                AvaragePrecisionRating = 0,
        //                AvarageReactionRating = 0,
        //                HarmonicPatterns = new List<HarmonicPattern>(),
        //                Value = "1d"
        //            },
        //            new Interval
        //            {
        //                AvaragePrecisionRating = 0,
        //                AvarageReactionRating = 0,
        //                HarmonicPatterns = new List<HarmonicPattern>(),
        //                Value = "1w"
        //            },
        //            new Interval
        //            {
        //                AvaragePrecisionRating = 0,
        //                AvarageReactionRating = 0,
        //                HarmonicPatterns = new List<HarmonicPattern>(),
        //                Value = "mn"
        //            }
        //        );

        //        context.SaveChanges();
        //    }
        //}


    }
}
