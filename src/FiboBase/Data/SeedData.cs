﻿using HarmonicPatternsBase.Models;
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
        public static void InstrumentsInit(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Instruments.Any())
                {
                    return;   // DB has been seeded
                }

                context.Instruments.AddRange
                (
                     new Instrument
                     {
                         AvaragePrecisionRating = 0,
                         AvarageReactionRating = 0,
                         HarmonicPatterns = new List<HarmonicPattern>(),
                         Name = "EUR/USD"
                     },
                     new Instrument
                     {
                         AvaragePrecisionRating = 0,
                         AvarageReactionRating = 0,
                         HarmonicPatterns = new List<HarmonicPattern>(),
                         Name = "GBP/USD"
                     },
                     new Instrument
                     {
                         AvaragePrecisionRating = 0,
                         AvarageReactionRating = 0,
                         HarmonicPatterns = new List<HarmonicPattern>(),
                         Name = "USD/JPN"
                     },
                     new Instrument
                     {
                         AvaragePrecisionRating = 0,
                         AvarageReactionRating = 0,
                         HarmonicPatterns = new List<HarmonicPattern>(),
                         Name = "USD/CHF"
                     },
                     new Instrument
                     {
                         AvaragePrecisionRating = 0,
                         AvarageReactionRating = 0,
                         HarmonicPatterns = new List<HarmonicPattern>(),
                         Name = "Zloto"
                     },
                     new Instrument
                     {
                         AvaragePrecisionRating = 0,
                         AvarageReactionRating = 0,
                         HarmonicPatterns = new List<HarmonicPattern>(),
                         Name = "Ropa"
                     },
                     new Instrument
                     {
                         AvaragePrecisionRating = 0,
                         AvarageReactionRating = 0,
                         HarmonicPatterns = new List<HarmonicPattern>(),
                         Name = "SP500"
                     }
                );

                context.SaveChanges();
            }
        }

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
                        ImageString = "~/images/harmonicPatterns/motyl.gif",
                        Name = "Motyl"
                    },
                    new Pattern
                    {
                        AvaragePrecisionRating = 0,
                        AvarageReactionRating = 0,
                        Description = "Korekta prosta",
                        HarmonicPatterns = new List<HarmonicPattern>(),
                        Image = new byte[1],
                        ImageString = "~/images/harmonicPatterns/abcd.gif",
                        Name = "ABCD"
                    },
                    new Pattern
                    {
                        AvaragePrecisionRating = 0,
                        AvarageReactionRating = 0,
                        Description = "Formacja gartleya",
                        HarmonicPatterns = new List<HarmonicPattern>(),
                        Image = new byte[1],
                        ImageString = "~/images/harmonicPatterns/gartley.gif",
                        Name = "Gartley"
                    },
                    new Pattern
                    {
                        AvaragePrecisionRating = 0,
                        AvarageReactionRating = 0,
                        Description = "Formacja kraba",
                        HarmonicPatterns = new List<HarmonicPattern>(),
                        Image = new byte[1],
                        ImageString = "~/images/harmonicPatterns/krab.gif",
                        Name = "Krab"
                    },
                    new Pattern
                    {
                        AvaragePrecisionRating = 0,
                        AvarageReactionRating = 0,
                        Description = "Formacja nietoperza",
                        HarmonicPatterns = new List<HarmonicPattern>(),
                        Image = new byte[1],
                        ImageString = "~/images/harmonicPatterns/nietoperz.gif",
                        Name = "Nietoperz"
                    },
                    new Pattern
                    {
                        AvaragePrecisionRating = 0,
                        AvarageReactionRating = 0,
                        Description = "Inne formache harmoniczne",
                        HarmonicPatterns = new List<HarmonicPattern>(),
                        Image = new byte[1],
                        ImageString = "~/images/harmonicPatterns/inny.gif",
                        Name = "Inny"
                    }
                );
                context.SaveChanges();
            }
        }

        public static void HarmonicPatternsInit(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.HarmonicPatterns.Any())
                {
                    return;   // DB has been seeded
                }

                var patternIdList = context.Patterns.Select(h => h.Id).ToList();
                var intervalIdList = context.Intervals.Select(h => h.Id).ToList();
                var instrumentIdList = context.Instruments.Select(h => h.Id).ToList();
                var hpList = HarmonicPatternsGenerator(20, patternIdList, intervalIdList, instrumentIdList);
                context.HarmonicPatterns.AddRange(hpList);
                context.SaveChanges();
            }
        }

        public static void AddHarmonicPatterns(IServiceProvider serviceProvider, int howMany)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                var patternIdList = context.Patterns.Select(h => h.Id).ToList();
                var intervalIdList = context.Intervals.Select(h => h.Id).ToList();
                var instrumentIdList = context.Instruments.Select(h => h.Id).ToList();
                var hpList = HarmonicPatternsGenerator(howMany, patternIdList, intervalIdList, instrumentIdList);
                context.HarmonicPatterns.AddRange(hpList);
                context.SaveChanges();
            }              
        }

        private static List<HarmonicPattern> HarmonicPatternsGenerator(
            int howMany, List<int> patternIdList, List<int> intervalIdList, List<int> instrumentIdList)
        {
            var hpList = new List<HarmonicPattern>();
            Random r = new Random();

            for (int i=0; i<howMany; i++)
            {

                hpList.Add(
                    new HarmonicPattern
                    {
                        AddDate = new DateTime(r.Next(2014, 2016), r.Next(1, 13), r.Next(1, 27)),
                        Date = new DateTime(r.Next(2014, 2016), r.Next(1, 13), r.Next(1, 27), r.Next(0, 24), r.Next(0, 60), 0),
                        AvaragePrecisionRating = r.Next(0, 11),
                        AvarageReactionRating = r.Next(0, 11),
                        Image = new byte[1],
                        NumberOfPrecisionRatings = r.Next(1, 100),
                        NumgerOfReactionRatings = r.Next(1, 100),
                        InstrumentId = instrumentIdList[r.Next(0, instrumentIdList.Count)],
                        PatternTypeId = patternIdList[r.Next(0, patternIdList.Count)],
                        IntervalId = intervalIdList[r.Next(0, intervalIdList.Count)],
                    }
                    );
            }
            return hpList;
        }
    }
}