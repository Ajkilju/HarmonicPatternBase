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

        public async Task<IActionResult> Index(int? intervalId = null, int? patternTypeId = null, int? instrumentId = null)
        {
            var statisticsData = await _statisticsRepo.GetHarmonicPatternStatisticisticDataAsync(intervalId, patternTypeId, instrumentId);

            var model = new StatisticsIndexViewModel
            {
                HarmonicPatterns = await _harmonicPatternsRepo
                      .GetHarmonicPatternsAsync(GetHarmonicPatternsMode.AsNoTracking, intervalId, patternTypeId, instrumentId, 20),
                Intervals = await _harmonicPatternsRepo.GetIntervalsAsync(GetIntervalsMode.AsNoTracking),
                PatternTypes = await _harmonicPatternsRepo.GetPatternTypesAsync(GetPatternTypesMode.AsNoTracking),
                Instruments = await _harmonicPatternsRepo.GetInstrumentsAsync(GetInstrumentTypesMode.AsNoTracking),

                SelectedInterval = await _harmonicPatternsRepo.GetIntervalAsync(GetIntervalsMode.AsNoTracking, intervalId),
                SelectedPattern = await _harmonicPatternsRepo.GetPatternTypeAsync(GetPatternTypesMode.AsNoTracking, patternTypeId),
                SelectedInstrument = await _harmonicPatternsRepo.GetInstrumentAsync(GetInstrumentTypesMode.AsNoTracking, instrumentId),

                SelectedPatternId = patternTypeId,
                SelectedIntervalId = intervalId,
                SelectedInstrumentId = instrumentId,
                Statistics = new HarmonicPatternsStatistic(statisticsData),
                ReactionLevels = _context.ReactionLvls.ToList()
            };


            return View(model);
        }
    }
}