using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HarmonicPatternsBase.Data;
using HarmonicPatternsBase.Models;
using HarmonicPatternsBase.Repositories.Abstract;
using HarmonicPatternsBase.Models.HarmonicPatternViewModels;
using HarmonicPatternsBase.Repositories;
using HarmonicPatternsBase.Models.StatisticModels;
using Sakura.AspNetCore;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Identity;
using HarmonicPatternBase.Repositories.Abstract;

namespace HarmonicPatternsBase.Controllers
{
    public class HarmonicPatternsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHarmonicPatternsRepo _harmonicPatternsRepo;
        private readonly IStatisticsRepo _statisticsRepo;
        private readonly IUsersRepo _usersRepo;

        public HarmonicPatternsController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            IHarmonicPatternsRepo harmonicPatternsRepo,
            IStatisticsRepo statisticsRepo,
            IUsersRepo usersRepo)
        {
            _context = context;
            _userManager = userManager;
            _harmonicPatternsRepo = harmonicPatternsRepo;
            _statisticsRepo = statisticsRepo;
            _usersRepo = usersRepo;
        }

       
        // GET: HarmonicPatterns
        public async Task<IActionResult> Index(
            int pageSize = 20,
            int page = 1,
            int sortOrder = 0,
            int viewOrder = 0,
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

            var model = new HarmonicPatternIndexViewModel
            {
                HarmonicPatterns = await _harmonicPatternsRepo
                      .GetHarmonicPatternsQuery(
                    GetHarmonicPatternsMode.AsNoTracking,
                    sortOrder,
                    intervalId, 
                    patternTypeId,
                    instrumentId,
                    patternDirectId,
                    dateSince,
                    dateTo,
                    addDateSince,
                    addDateTo,
                    userId)
                    .ToPagedListAsync(pageSize, page),

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

                Statistics = new HarmonicPatternsStatistic(statisticsData,reactionIds, GetStatisticsMode.Basic),  
                
                 SortOrder = sortOrder,
                 SortOrdersList = new List<string>
                 {
                     "Data malejaco",
                     "Data rosnaco",
                     "Data dodania malejaco",
                     "Data dodania rosnaco"
                 },
                 ViewOrder = viewOrder,
                 ViewOrdersList = new List<string>
                 {
                     "Kafelki",
                     "Lista"
                 },
            };

            if(userId != null)
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

        // GET: HarmonicPatterns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = new HarmonicPatternDetailsViewModel
            {
                HarmonicPattern = await _harmonicPatternsRepo.GetHarmonicPatternAsync(GetHarmonicPatternsMode.Tracking, id)
            };

            return View(model);
        }

        // GET: HarmonicPatterns/Create
        public IActionResult Create()
        {
            var waveRatioList = new List<string> { "0", "0.382", "0.5", "0.618", "0.786", "0.886", "1", "1.13", "1.227", "1.618", "2" };

            var model = new HarmonicPatternCreateViewModel
            {
                HarmonicPattern = new HarmonicPattern(),
                IntervalList = new SelectList(_context.Intervals, "Id", "Name"),
                PatternTypeList = new SelectList(_context.Patterns, "Id", "Name"),
                InstrumentList = new SelectList(_context.Instruments, "Id", "Name"),
                PatternDirectList = new SelectList(_context.PatternDirects, "Id", "Name"),
                ReactionLvlsList = new SelectList(_context.ReactionLvls, "Id", "Name"),
                WaveRatioList = new SelectList(waveRatioList),
                NumberOfWavesList = new SelectList(new List<int> { 3, 4 }),
            };

            return View(model);
        }

        // POST: HarmonicPatterns/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HarmonicPatternCreateViewModel model, IFormFile image)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (ModelState.IsValid)
            {
                if (image == null)
                {
                    model.HarmonicPattern.Image = new byte[1];
                }
                else
                {
                    using (var reader = new BinaryReader(image.OpenReadStream()))
                    {
                        var fileContent = reader.ReadBytes((int)image.Length);
                        model.HarmonicPattern.Image = fileContent;
                    }
                }
                model.HarmonicPattern.Date = model.Date.Date + model.Time.TimeOfDay;
                model.HarmonicPattern.AddDate = DateTime.Now;

                model.HarmonicPattern.ABtoXAratio = double.Parse(model.ABtoXAratio, System.Globalization.CultureInfo.InvariantCulture);
                model.HarmonicPattern.ADtoXAratio = double.Parse(model.ADtoXAratio, System.Globalization.CultureInfo.InvariantCulture);
                model.HarmonicPattern.BCtoABratio = double.Parse(model.BCtoABratio, System.Globalization.CultureInfo.InvariantCulture);
                model.HarmonicPattern.CDtoBCratio = double.Parse(model.CDtoBCratio, System.Globalization.CultureInfo.InvariantCulture);
                model.HarmonicPattern.CDtoABratio = double.Parse(model.CDtoABratio, System.Globalization.CultureInfo.InvariantCulture);

                if(user != null)
                {
                    model.HarmonicPattern.UserId = user.Id;
                }

                _harmonicPatternsRepo.AddHarmonicPattern(model.HarmonicPattern);
                await _harmonicPatternsRepo.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: HarmonicPatterns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var harmonicPattern = await _context.HarmonicPatterns.SingleOrDefaultAsync(m => m.Id == id);
            if (harmonicPattern == null)
            {
                return NotFound();
            }
            ViewData["IntervalId"] = new SelectList(_context.Intervals, "Id", "Id", harmonicPattern.IntervalId);
            ViewData["PatternTypeId"] = new SelectList(_context.Patterns, "Id", "Id", harmonicPattern.PatternTypeId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", harmonicPattern.UserId);
            return View(harmonicPattern);
        }

        // POST: HarmonicPatterns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AddDate,AvaragePrecisionRating,AvarageReactionRating,Date,Discription,Image,Instrument,IntervalId,NumberOfPrecisionRatings,NumgerOfReactionRatings,PatternTypeId,UserId")] HarmonicPattern harmonicPattern)
        {
            if (id != harmonicPattern.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(harmonicPattern);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HarmonicPatternExists(harmonicPattern.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["IntervalId"] = new SelectList(_context.Intervals, "Id", "Id", harmonicPattern.IntervalId);
            ViewData["PatternTypeId"] = new SelectList(_context.Patterns, "Id", "Id", harmonicPattern.PatternTypeId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", harmonicPattern.UserId);
            return View(harmonicPattern);
        }

        // GET: HarmonicPatterns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var harmonicPattern = await _context.HarmonicPatterns.SingleOrDefaultAsync(m => m.Id == id);
            if (harmonicPattern == null)
            {
                return NotFound();
            }

            return View(harmonicPattern);
        }

        // POST: HarmonicPatterns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var harmonicPattern = await _context.HarmonicPatterns.SingleOrDefaultAsync(m => m.Id == id);
            _context.HarmonicPatterns.Remove(harmonicPattern);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool HarmonicPatternExists(int id)
        {
            return _context.HarmonicPatterns.Any(e => e.Id == id);
        }
    }
}
