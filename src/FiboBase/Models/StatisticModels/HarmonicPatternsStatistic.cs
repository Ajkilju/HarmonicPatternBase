using HarmonicPatternsBase.Models.StatisticModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarmonicPatternsBase.Models.StatisticModels
{
    public enum GetStatisticsMode {Basic, Full};

    //HarmonicPatternStatistics - klasa, ktora okresla dane dla HarmonicPatternsStatistics
    //HarmonicPatternsStatistics - klasa, w ktorej obliczane są statystyki

    public class HarmonicPatternsStatistic
    {
        public HarmonicPatternsStatistic(List<HarmonicPatternStatistic> data, List<int> reactionIds, GetStatisticsMode mode)
        {
            ReactionAfter5Candles = new List<ReactionStatistic>();
            ReactionAfter10Candles = new List<ReactionStatistic>();
            ReactionAfter20Candles = new List<ReactionStatistic>();

            Count = data.Count();

            foreach (var reaction in reactionIds)
            {
                var reactionCon = data.Where(h => h.ReactionAfter5CandlesId == reaction).Count();
                ReactionAfter5Candles.Add(
                    new ReactionStatistic
                    {
                        ReactionId = reaction,
                        Data = data.Where(h => h.ReactionAfter5CandlesId == reaction),
                        ReactionCon = reactionCon,
                        PercentOfAllData = (double)reactionCon / (double)Count * 100.0
                    }
                    );

                reactionCon = data.Where(h => h.ReactionAfter10CandlesId == reaction).Count();
                ReactionAfter10Candles.Add(
                    new ReactionStatistic
                    {
                        ReactionId = reaction,
                        Data = data.Where(h => h.ReactionAfter10CandlesId == reaction),
                        ReactionCon = reactionCon,
                        PercentOfAllData = (double)reactionCon / (double)Count * 100.0
                    }
                    );

                reactionCon = data.Where(h => h.ReactionAfter20CandlesId == reaction).Count();
                ReactionAfter20Candles.Add(
                    new ReactionStatistic
                    {
                        ReactionId = reaction,
                        Data = data.Where(h => h.ReactionAfter20CandlesId == reaction),
                        ReactionCon = reactionCon,
                        PercentOfAllData = (double)reactionCon / (double)Count * 100.0
                    }
                    );
            }

            //full opcja, wszystkie statystyki
            if(mode == GetStatisticsMode.Full)
            {
                ReactionFrom5candlesTo10candles = new List<ReactionAfterReaction>();
                ReactionFrom5candlesTo20candles = new List<ReactionAfterReaction>();

                foreach(var reactionAfter5c in ReactionAfter5Candles)
                {
                    foreach(var reaction in reactionIds)
                    {
                        var reaction5to10Con = reactionAfter5c.Data.Where(h => h.ReactionAfter10CandlesId == reaction).Count();
                        var reaction5to20Con = reactionAfter5c.Data.Where(h => h.ReactionAfter20CandlesId == reaction).Count();

                        ReactionFrom5candlesTo10candles.Add
                            (
                            new ReactionAfterReaction
                            {
                                FirstReactionId = reactionAfter5c.ReactionId,
                                SecondReactionId = reaction,
                                Percent = (double)reaction5to10Con / (double)reactionAfter5c.ReactionCon * 100.0,
                                PercentOfAllData = (double)reaction5to10Con / (double)Count * 100.0
                            });

                        ReactionFrom5candlesTo20candles.Add
                            (
                            new ReactionAfterReaction
                            {
                                FirstReactionId = reactionAfter5c.ReactionId,
                                SecondReactionId = reaction,
                                Percent = (double)reaction5to20Con / (double)reactionAfter5c.ReactionCon * 100.0,
                                PercentOfAllData = (double)reaction5to20Con / (double)Count * 100.0
                            });
                    }
                }

                ReactionFrom5candlesTo10candles = ReactionFrom5candlesTo10candles.OrderBy(h => h.FirstReactionId).ToList();
                ReactionFrom5candlesTo20candles = ReactionFrom5candlesTo20candles.OrderBy(h => h.FirstReactionId).ToList();
            }
        }

        public int Count { get; set; }

        public List<ReactionStatistic> ReactionAfter5Candles { get; set; }
        public List<ReactionStatistic> ReactionAfter10Candles { get; set; }
        public List<ReactionStatistic> ReactionAfter20Candles { get; set; }

        public List<ReactionAfterReaction> ReactionFrom5candlesTo10candles { get; set; }
        public List<ReactionAfterReaction> ReactionFrom5candlesTo20candles { get; set; }
    }    
}
