using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarmonicPatternsBase.Models.StatisticModels
{
    //ile ukladow ,ktore dochodzą do B dochodzi do A? i po ilu swiecach?
    public class ReactionAfterReaction
    {
        //pierwszy osiągnięty poziom
        public int FirstReactionId { get; set; }
        //drugi osiągnięty poziom
        public int SecondReactionId { get; set; }

        //jaki procent ukladow dochodzacych do pierwszego poziomu dochodzi do drugiego
        public double Percent { get; set; }

        //procent z calych danych wejsciowych
        public double PercentOfAllData { get; set; }
    }
}
