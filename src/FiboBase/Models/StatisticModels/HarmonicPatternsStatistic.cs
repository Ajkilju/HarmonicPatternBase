using HarmonicPatternsBase.Models.StatisticModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarmonicPatternsBase.Models.StatisticModels
{
    public class HarmonicPatternsStatistic
    {
        public HarmonicPatternsStatistic(List<HarmonicPatternStatistic> data)
        {
            NumberOfWaves = 0;
            ABtoXAratio = 0;
            ADtoXAratio = 0;
            BCtoABratio = 0;
            CDtoBCratio = 0;
            CDtoABratio = 0;

            ReactionAfter5Candles = new List<ReactionStatistic>();
            ReactionAfter10Candles = new List<ReactionStatistic>();
            ReactionAfter20Candles = new List<ReactionStatistic>();

            foreach (var item in data)
            {
                NumberOfWaves += item.NumberOfWaves;
                ABtoXAratio += item.ABtoXAratio;
                ADtoXAratio += item.ADtoXAratio;
                BCtoABratio += item.BCtoABratio;
                CDtoBCratio += item.CDtoBCratio;
                CDtoABratio += item.CDtoABratio;

                ReactionAfter5Found = false;
                ReactionAfter10Found = false;
                ReactionAfter20Found = false;

                foreach (var reaction in ReactionAfter5Candles)
                {
                    if(item.ReactionAfter5CandlesId == reaction.ReactionId && ReactionAfter5Found == false)
                    {
                        reaction.ReactionCon++;
                        ReactionAfter5Found = true;
                    }
                }

                foreach (var reaction in ReactionAfter10Candles)
                {
                    if (item.ReactionAfter10CandlesId == reaction.ReactionId && ReactionAfter10Found == false)
                    {
                        reaction.ReactionCon++;
                        ReactionAfter10Found = true;
                    }
                }

                foreach (var reaction in ReactionAfter20Candles)
                {
                    if (item.ReactionAfter20CandlesId == reaction.ReactionId && ReactionAfter20Found == false)
                    {
                        reaction.ReactionCon++;
                        ReactionAfter20Found = true;
                    }
                }

                if(ReactionAfter5Found == false)
                {
                    ReactionAfter5Candles.Add(new ReactionStatistic { ReactionId = (int)item.ReactionAfter5CandlesId, ReactionCon = 1 });
                }
                if (ReactionAfter10Found == false)
                {
                    ReactionAfter10Candles.Add(new ReactionStatistic { ReactionId = (int)item.ReactionAfter10CandlesId, ReactionCon = 1 });
                }
                if (ReactionAfter20Found == false)
                {
                    ReactionAfter20Candles.Add(new ReactionStatistic { ReactionId = (int)item.ReactionAfter20CandlesId, ReactionCon = 1 });
                }
            }

            NumberOfWaves = NumberOfWaves / data.Count;
            ABtoXAratio = ABtoXAratio / data.Count;
            ADtoXAratio = ADtoXAratio / data.Count;
            BCtoABratio = BCtoABratio / data.Count;
            CDtoBCratio = CDtoBCratio / data.Count;
            CDtoABratio = CDtoABratio / data.Count;
            Count = data.Count;

            ReactionAfter5Candles = ReactionAfter5Candles.OrderBy(h => h.ReactionId).ToList();
            ReactionAfter10Candles = ReactionAfter10Candles.OrderBy(h => h.ReactionId).ToList();
            ReactionAfter20Candles = ReactionAfter20Candles.OrderBy(h => h.ReactionId).ToList();
        }

        public int Count { get; set; }
        public int? NumberOfWaves { get; set; }
        public double? ABtoXAratio { get; set; }
        public double? ADtoXAratio { get; set; }
        public double? BCtoABratio { get; set; }
        public double? CDtoBCratio { get; set; }
        public double? CDtoABratio { get; set; }

        public List<ReactionStatistic> ReactionAfter5Candles { get; set; }
        public List<ReactionStatistic> ReactionAfter10Candles { get; set; }
        public List<ReactionStatistic> ReactionAfter20Candles { get; set; }

        private bool ReactionAfter5Found;
        private bool ReactionAfter10Found;
        private bool ReactionAfter20Found;
    }

    public class ReactionStatistic
    {
        public int ReactionId { get; set; }
        public int ReactionCon { get; set; }
    }
}
