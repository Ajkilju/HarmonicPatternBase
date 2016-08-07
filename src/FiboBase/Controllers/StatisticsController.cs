using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HarmonicPatternsBase.Repositories.Abstract;
using HarmonicPatternsBase.Models.StatisticsViewModels;
using HarmonicPatternsBase.Repositories;
using HarmonicPatternsBase.Models.StatisticModels;
using HarmonicPatternsBase.Data;

namespace HarmonicPatternsBase.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHarmonicPatternsRepo _harmonicPatternsRepo;
        private readonly IStatisticsRepo _statisticsRepo;

        public StatisticsController(
            ApplicationDbContext context,
            IHarmonicPatternsRepo harmonicPatternsRepo,
            IStatisticsRepo statisticsRepo)
        {
            _context = context;
            _harmonicPatternsRepo = harmonicPatternsRepo;
            _statisticsRepo = statisticsRepo;
        }

        public async Task<IActionResult> Index(
            int? intervalId = null, int? patternTypeId = null, int? instrumentId = null, int? patternDirectId = null)
        {
            var statisticsData = await _statisticsRepo.GetHarmonicPatternStatisticisticDataAsync(
                intervalId, patternTypeId, instrumentId, patternDirectId);

            var model = new StatisticsIndexViewModel
            {
                Intervals = await _harmonicPatternsRepo.GetIntervalsAsync(),
                PatternTypes = await _harmonicPatternsRepo.GetPatternTypesAsync(),
                Instruments = await _harmonicPatternsRepo.GetInstrumentsAsync(),
                PatternDirects = await _harmonicPatternsRepo.GetPatternDirectsAsync(),

                SelectedInterval = await _harmonicPatternsRepo.GetIntervalAsync(intervalId),
                SelectedPattern = await _harmonicPatternsRepo.GetPatternTypeAsync(patternTypeId),
                SelectedInstrument = await _harmonicPatternsRepo.GetInstrumentAsync(instrumentId),
                SelectedDirect = await _harmonicPatternsRepo.GetPatternDirectAsync(patternDirectId),

                SelectedPatternId = patternTypeId,
                SelectedIntervalId = intervalId,
                SelectedInstrumentId = instrumentId,
                SelectedDirectId = patternDirectId,

                Statistics = new HarmonicPatternsStatistic(statisticsData),
                ReactionLevels = _context.ReactionLvls.ToList()
            };


            return View(model);
        }
    }
}