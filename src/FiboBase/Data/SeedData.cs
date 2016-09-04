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
                    //mayors
                     new Instrument
                     {
                         HarmonicPatterns = new List<HarmonicPattern>(),
                         Name = "EUR/USD",
                         Category = "Majors"
                     },
                     new Instrument
                     {
                         HarmonicPatterns = new List<HarmonicPattern>(),
                         Name = "GBP/USD",
                         Category = "Majors"
                     },
                     new Instrument
                     {
                         HarmonicPatterns = new List<HarmonicPattern>(),
                         Name = "USD/CAD",
                         Category = "Majors"
                     },
                     new Instrument
                     {
                         HarmonicPatterns = new List<HarmonicPattern>(),
                         Name = "USD/CHF",
                         Category = "Majors"
                     },
                     new Instrument
                     {
                         HarmonicPatterns = new List<HarmonicPattern>(),
                         Name = "USD/JPY",
                         Category = "Majors"
                     },
                     new Instrument
                     {
                         HarmonicPatterns = new List<HarmonicPattern>(),
                         Name = "AUD/USD",
                         Category = "Majors"
                     },
                     new Instrument
                     {
                         HarmonicPatterns = new List<HarmonicPattern>(),
                         Name = "NZD/USD",
                         Category = "Majors"
                     },

                     //second mayors

                     new Instrument
                     {
                         HarmonicPatterns = new List<HarmonicPattern>(),
                         Name = "EUR/JPY",
                         Category = "Second Majors"
                     },
                     new Instrument
                     {
                         HarmonicPatterns = new List<HarmonicPattern>(),
                         Name = "EUR/CHF",
                         Category = "Second Majors"
                     },
                     new Instrument
                     {
                         HarmonicPatterns = new List<HarmonicPattern>(),
                         Name = "GBP/JPY",
                         Category = "Second Majors"
                     },
                     new Instrument
                     {
                         HarmonicPatterns = new List<HarmonicPattern>(),
                         Name = "EUR/GBP",
                         Category = "Second Majors"
                     },
                     new Instrument
                     {
                         HarmonicPatterns = new List<HarmonicPattern>(),
                         Name = "GBP/CHF",
                         Category = "Second Majors"
                     },
                     new Instrument
                     {
                         HarmonicPatterns = new List<HarmonicPattern>(),
                         Name = "EUR/CAD",
                         Category = "Second Majors"
                     },
                     new Instrument
                     {
                         HarmonicPatterns = new List<HarmonicPattern>(),
                         Name = "GBP/CAD",
                         Category = "Second Majors"
                     },
                     new Instrument
                     {
                         HarmonicPatterns = new List<HarmonicPattern>(),
                         Name = "NZD/JPY",
                         Category = "Second Majors"
                     },
                     new Instrument
                     {
                         HarmonicPatterns = new List<HarmonicPattern>(),
                         Name = "NZD/CHF",
                         Category = "Second Majors"
                     },
                     new Instrument
                     {
                         HarmonicPatterns = new List<HarmonicPattern>(),
                         Name = "EUR/AUD",
                         Category = "Second Majors"
                     },
                     new Instrument
                     {
                         HarmonicPatterns = new List<HarmonicPattern>(),
                         Name = "AUD/JPY",
                         Category = "Second Majors"
                     },
                     new Instrument
                     {
                         HarmonicPatterns = new List<HarmonicPattern>(),
                         Name = "AUD/CAD",
                         Category = "Second Majors"
                     },
                     new Instrument
                     {
                         HarmonicPatterns = new List<HarmonicPattern>(),
                         Name = "AUD/CHF",
                         Category = "Second Majors"
                     },
                     new Instrument
                     {
                         HarmonicPatterns = new List<HarmonicPattern>(),
                         Name = "CHF/JPY",
                         Category = "Second Majors"
                     },
                     new Instrument
                     {
                         HarmonicPatterns = new List<HarmonicPattern>(),
                         Name = "CAD/JPY",
                         Category = "Second Majors"
                     },
                     new Instrument
                     {
                         HarmonicPatterns = new List<HarmonicPattern>(),
                         Name = "CAD/CHF",
                         Category = "Second Majors"
                     },

                     //Polskie

                     new Instrument
                     {
                         HarmonicPatterns = new List<HarmonicPattern>(),
                         Name = "USD/PLN",
                         Category = "Polskie"
                     },
                     new Instrument
                     {
                         HarmonicPatterns = new List<HarmonicPattern>(),
                         Name = "EUR/PLN",
                         Category = "Polskie"
                     },
                     new Instrument
                     {
                         HarmonicPatterns = new List<HarmonicPattern>(),
                         Name = "GBP/PLN",
                         Category = "Polskie"
                     },
                     new Instrument
                     {
                         HarmonicPatterns = new List<HarmonicPattern>(),
                         Name = "CHF/PLN",
                         Category = "Polskie"
                     },
                     new Instrument
                     {
                         HarmonicPatterns = new List<HarmonicPattern>(),
                         Name = "JPY/PLN",
                         Category = "Polskie"
                     },

                     //surowce

                     new Instrument
                     {
                         HarmonicPatterns = new List<HarmonicPattern>(),
                         Name = "Złoto",
                         Category = "Surowce"
                     },
                     new Instrument
                     {
                         HarmonicPatterns = new List<HarmonicPattern>(),
                         Name = "Ropa",
                         Category = "Surowce"
                     },
                     new Instrument
                     {
                         HarmonicPatterns = new List<HarmonicPattern>(),
                         Name = "Miedź",
                         Category = "Surowce"
                     },
                     new Instrument
                     {
                         HarmonicPatterns = new List<HarmonicPattern>(),
                         Name = "Kukurydza",
                         Category = "Surowce"
                     },
                     new Instrument
                     {
                         HarmonicPatterns = new List<HarmonicPattern>(),
                         Name = "Ryż",
                         Category = "Surowce"
                     },
                     new Instrument
                     {
                         HarmonicPatterns = new List<HarmonicPattern>(),
                         Name = "Cukier",
                         Category = "Surowce"
                     },
                     new Instrument
                     {
                         HarmonicPatterns = new List<HarmonicPattern>(),
                         Name = "Kakao",
                         Category = "Surowce"
                     },
                     new Instrument
                     {
                         HarmonicPatterns = new List<HarmonicPattern>(),
                         Name = "Bawełna",
                         Category = "Surowce"
                     },

                     //indeksy giełdowe

                     new Instrument
                     {
                         HarmonicPatterns = new List<HarmonicPattern>(),
                         Name = "FUS500",
                         Category = "Indeksy"
                     },
                     new Instrument
                     {
                         HarmonicPatterns = new List<HarmonicPattern>(),
                         Name = "FUS100",
                         Category = "Indeksy"
                     },
                     new Instrument
                     {
                         HarmonicPatterns = new List<HarmonicPattern>(),
                         Name = "FJP225",
                         Category = "Indeksy"
                     },
                     new Instrument
                     {
                         HarmonicPatterns = new List<HarmonicPattern>(),
                         Name = "FDE30",
                         Category = "Indeksy"
                     },
                     new Instrument
                     {
                         HarmonicPatterns = new List<HarmonicPattern>(),
                         Name = "FPL20",
                         Category = "Indeksy"
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
                        HarmonicPatterns = new List<HarmonicPattern>(),
                        Name = "1m"
                    },
                    new Interval
                    {
                        HarmonicPatterns = new List<HarmonicPattern>(),
                        Name = "5m"
                    },
                    new Interval
                    {
                        HarmonicPatterns = new List<HarmonicPattern>(),
                        Name = "15m"
                    },
                    new Interval
                    {
                        HarmonicPatterns = new List<HarmonicPattern>(),
                        Name = "30m"
                    },
                    new Interval
                    {
                        HarmonicPatterns = new List<HarmonicPattern>(),
                        Name = "1h"
                    },
                    new Interval
                    {
                        HarmonicPatterns = new List<HarmonicPattern>(),
                        Name = "4h"
                    },
                    new Interval
                    {
                        HarmonicPatterns = new List<HarmonicPattern>(),
                        Name = "1d"
                    },
                    new Interval
                    {
                        HarmonicPatterns = new List<HarmonicPattern>(),
                        Name = "1w"
                    },
                    new Interval
                    {
                        HarmonicPatterns = new List<HarmonicPattern>(),
                        Name = "mn"
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
                        Description = "Formacja motyla",
                        HarmonicPatterns = new List<HarmonicPattern>(),
                        Image = new byte[1],
                        ImageString = "~/images/harmonicPatterns/motyl.gif",
                        Name = "Motyl",
                        NumberOfWaves = 4,
                        ABtoXAratio = 0.786,
                        ADtoXAratio = 1.272,
                        //szeroki zakres. dac jako liste?
                        BCtoABratio = 0,
                        CDtoBCratio = 0,
                        CDtoABratio = 0
                    },
                    new Pattern
                    {
                        Description = "Korekta prosta",
                        HarmonicPatterns = new List<HarmonicPattern>(),
                        Image = new byte[1],
                        ImageString = "~/images/harmonicPatterns/abcd.gif",
                        Name = "ABCD",
                        NumberOfWaves = 3,
                        ABtoXAratio = 0,
                        ADtoXAratio = 0,
                        //szeroki zakres. dac jako liste?
                        BCtoABratio = 0,
                        CDtoBCratio = 0,
                        CDtoABratio = 1
                    },
                    new Pattern
                    {
                        Description = "Formacja gartleya",
                        HarmonicPatterns = new List<HarmonicPattern>(),
                        Image = new byte[1],
                        ImageString = "~/images/harmonicPatterns/gartley.gif",
                        Name = "Gartley",
                        NumberOfWaves = 4,
                        ABtoXAratio = 0.618,
                        ADtoXAratio = 0.786,
                        //szeroki zakres. dac jako liste?
                        BCtoABratio = 0,
                        CDtoBCratio = 0,
                        CDtoABratio = 0
                    },
                    new Pattern
                    {
                        Description = "Formacja kraba",
                        HarmonicPatterns = new List<HarmonicPattern>(),
                        Image = new byte[1],
                        ImageString = "~/images/harmonicPatterns/krab.gif",
                        Name = "Krab",
                        NumberOfWaves = 4,
                        ABtoXAratio = 0.382,
                        ADtoXAratio = 1.618,
                        //szeroki zakres. dac jako liste?
                        BCtoABratio = 0,
                        CDtoBCratio = 0,
                        CDtoABratio = 0
                    },
                    new Pattern
                    {
                        Description = "Formacja nietoperza",
                        HarmonicPatterns = new List<HarmonicPattern>(),
                        Image = new byte[1],
                        ImageString = "~/images/harmonicPatterns/nietoperz.gif",
                        Name = "Nietoperz",
                        NumberOfWaves = 4,
                        ABtoXAratio = 0.382,
                        ADtoXAratio = 0.886,
                        //szeroki zakres. dac jako liste?
                        BCtoABratio = 0,
                        CDtoBCratio = 0,
                        CDtoABratio = 0
                    },
                    new Pattern
                    {
                        Description = "Inne formache harmoniczne",
                        HarmonicPatterns = new List<HarmonicPattern>(),
                        Image = new byte[1],
                        ImageString = "~/images/harmonicPatterns/inny.gif",
                        Name = "Inny",
                        NumberOfWaves = 0,
                        ABtoXAratio = 0,
                        ADtoXAratio = 0,
                        //szeroki zakres. dac jako liste?
                        BCtoABratio = 0,
                        CDtoBCratio = 0,
                        CDtoABratio = 0

                    }
                );
                context.SaveChanges();
            }
        }

        public static void PatternDirectInit(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.PatternDirects.Any())
                {
                    return;   // DB has been seeded
                }

                context.PatternDirects.AddRange
                (
                     new PatternDirect
                     {
                         Name = "Spadkowy"
                     },
                     new PatternDirect
                     {
                         Name = "Wzrostowy"
                     }
                );

                context.SaveChanges();
            }
        }

        public static void ReactionLvlsInit(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.ReactionLvls.Any())
                {
                    return;   // DB has been seeded
                }

                context.ReactionLvls.AddRange
                (
                     new ReactionLvl
                     {
                         Name = "-D"
                     },
                     new ReactionLvl
                     {
                         Name = "DB"
                     },
                     new ReactionLvl
                     {
                         Name = "BC"
                     },
                     new ReactionLvl
                     {
                         Name = "CA"
                     },
                     new ReactionLvl
                     {
                         Name = "A+"
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
                var reactionLvlsList = context.ReactionLvls.Select(h => h.Id).ToList();
                var patternDirectIdList = context.PatternDirects.Select(h => h.Id).ToList();
                List<double> waveRatioList = new List<double> { 0.382, 0.5, 0.618, 0.786, 0.886, 1.0, 1.13, 1.227, 1.618, 2.0 };
                var hpList = HarmonicPatternsGenerator(
                    20,
                    patternIdList,
                    intervalIdList,
                    instrumentIdList,
                    reactionLvlsList,
                    waveRatioList,
                    patternDirectIdList);
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
                var reactionLvlsList = context.ReactionLvls.Select(h => h.Id).ToList();
                var patternDirectIdList = context.PatternDirects.Select(h => h.Id).ToList();
                List<double> waveRatioList = new List<double> {0.000, 0.382, 0.500, 0.618, 0.786, 0.886, 1.000, 1.13, 1.227, 1.618, 2.000 };
                var hpList = HarmonicPatternsGenerator(
                    howMany, 
                    patternIdList, 
                    intervalIdList, 
                    instrumentIdList,
                    reactionLvlsList,
                    waveRatioList,
                    patternDirectIdList);
                context.HarmonicPatterns.AddRange(hpList);
                context.SaveChanges();
            }              
        }

        private static List<HarmonicPattern> HarmonicPatternsGenerator(
            int howMany, 
            List<int> patternIdList,
            List<int> intervalIdList, 
            List<int> instrumentIdList,
            List<int> reactionLvlsList,
            List<double> waveRatioList,
            List<int> patternDirectIdList)
        {
            var hpList = new List<HarmonicPattern>();
            Random r = new Random();

            for (int i=0; i<howMany; i++)
            {

                hpList.Add(
                    new HarmonicPattern
                    {
                        AddDate = new DateTime(r.Next(2014, 2017), r.Next(1, 13), r.Next(1, 27)),
                        Date = new DateTime(r.Next(2014, 2017), r.Next(1, 13), r.Next(1, 27), r.Next(0, 24), r.Next(0, 60), 0),
                        Image = new byte[1],
                        InstrumentId = instrumentIdList[r.Next(0, instrumentIdList.Count)],
                        PatternTypeId = patternIdList[r.Next(0, patternIdList.Count)],
                        IntervalId = intervalIdList[r.Next(0, intervalIdList.Count)],
                        ABtoXAratio = waveRatioList[r.Next(0, waveRatioList.Count)],
                        ADtoXAratio = waveRatioList[r.Next(0, waveRatioList.Count)],
                        BCtoABratio = waveRatioList[r.Next(0, waveRatioList.Count)],
                        CDtoABratio = waveRatioList[r.Next(0, waveRatioList.Count)],
                        CDtoBCratio = waveRatioList[r.Next(0, waveRatioList.Count)],
                        NumberOfWaves = 4,
                        ReactionAfter5CandlesId = reactionLvlsList[r.Next(0, reactionLvlsList.Count)],
                        ReactionAfter10CandlesId = reactionLvlsList[r.Next(0, reactionLvlsList.Count)],
                        ReactionAfter20CandlesId = reactionLvlsList[r.Next(0, reactionLvlsList.Count)],
                        PatternDirectId = patternDirectIdList[r.Next(0, patternDirectIdList.Count)]
                    }
                    );
            }
            return hpList;
        }
    }
}
