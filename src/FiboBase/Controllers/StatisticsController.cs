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
using HarmonicPatternBase.Repositories.Abstract;

namespace HarmonicPatternsBase.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHarmonicPatternsRepo _harmonicPatternsRepo;
        private readonly IStatisticsRepo _statisticsRepo;
        private readonly IUsersRepo _usersRepo;

        public StatisticsController(
            ApplicationDbContext context,
            IHarmonicPatternsRepo harmonicPatternsRepo,
            IStatisticsRepo statisticsRepo,
            IUsersRepo usersRepo)
        {
            _context = context;
            _harmonicPatternsRepo = harmonicPatternsRepo;
            _statisticsRepo = statisticsRepo;
            _usersRepo = usersRepo;
        }

        public async Task<IActionResult> Index(
            int? intervalId = null,
            int? patternTypeId = null,
            int? instrumentId = null,
            int? patternDirectId = null,
            DateTime? dateSince = null,
            DateTime? dateTo = null,
            DateTime? addDateSince = null,
            DateTime? addDateTo = null,
            string userId = null)
        {
            var statisticsData = await _statisticsRepo.GetHarmonicPatternStatisticisticDataAsync(
                intervalId,
                patternTypeId,
                instrumentId,
                patternDirectId,
                dateSince,
                dateTo,
                addDateSince,
                addDateTo);
            var reactionIds = _statisticsRepo.GetReactionIds();

            var model = new StatisticsIndexViewModel
            {
                DateSince = dateSince,
                DateTo = dateTo,
                AddDateSince = addDateSince,
                AddDateTo = addDateTo,

                Intervals = await _harmonicPatternsRepo.GetIntervalsAsync(),
                PatternTypes = await _harmonicPatternsRepo.GetPatternTypesAsync(),
                PatternDirects = await _harmonicPatternsRepo.GetPatternDirectsAsync(),
                ReactionLevels = await _harmonicPatternsRepo.GetReactionLvlsAsync(),

                SelectedInterval = await _harmonicPatternsRepo.GetIntervalAsync(intervalId),
                SelectedPattern = await _harmonicPatternsRepo.GetPatternTypeAsync(patternTypeId),
                SelectedInstrument = await _harmonicPatternsRepo.GetInstrumentAsync(instrumentId),
                SelectedDirect = await _harmonicPatternsRepo.GetPatternDirectAsync(patternDirectId),

                SelectedPatternId = patternTypeId,
                SelectedIntervalId = intervalId,
                SelectedInstrumentId = instrumentId,
                SelectedDirectId = patternDirectId,
                SelectedUserId = userId,

                Statistics = new HarmonicPatternsStatistic(statisticsData, reactionIds, GetStatisticsMode.Full),
            };

            if (userId != null)
            {
                model.SelectedUser = await _usersRepo.GetUserAsync(userId);
            }
            else
            {
                model.SelectedUser = null;
            }

            model.SetInstruments(await _harmonicPatternsRepo.GetInstrumentsAsync());

            DateTime d = DateTime.Now;

            if (dateSince != null)
            {
                d = (DateTime)dateSince;
                model.DateSinceString = d.Year.ToString() + "-" + d.Month.ToString("00") + "-" + d.Day.ToString("00");
            }

            if (dateTo != null)
            {
                d = (DateTime)dateTo;
                model.DateToString = d.Year.ToString() + "-" + d.Month.ToString("00") + "-" + d.Day.ToString("00");
            }

            if (addDateSince != null)
            {
                d = (DateTime)addDateSince;
                model.AddDateSinceString = d.Year.ToString() + "-" + d.Month.ToString("00") + "-" + d.Day.ToString("00");
            }

            if (addDateTo != null)
            {
                d = (DateTime)addDateTo;
                model.AddDateToString = d.Year.ToString() + "-" + d.Month.ToString("00") + "-" + d.Day.ToString("00");
            }

            return View(model);
        }
    }
}