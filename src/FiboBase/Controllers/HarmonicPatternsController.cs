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

namespace HarmonicPatternsBase.Controllers
{
    public class HarmonicPatternsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHarmonicPatternsRepo _harmonicPatternsRepo;

        public HarmonicPatternsController(ApplicationDbContext context, IHarmonicPatternsRepo harmonicPatternsRepo)
        {
            _context = context;
            _harmonicPatternsRepo = harmonicPatternsRepo;
        }

        // GET: HarmonicPatterns
        public async Task<IActionResult> Index(int? intervalId = null, int? patternTypeId = null, int? instrumentId = null)
        {
            var statisticsData = await _harmonicPatternsRepo.GetHarmonicPatternStatAsync(intervalId, patternTypeId, instrumentId);

            var model = new HarmonicPatternIndexViewModel
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
            var dayList = new List<int>();
            for(int i=1; i<32; i++)
            {
                dayList.Add(i);
            }

            var monthList = new List<int>();
            for(int i=1; i<13; i++)
            {
                monthList.Add(i);
            }

            var yearList = new List<int>();
            for (int i = 2000; i < DateTime.Now.Year + 1; i++)
            {
                yearList.Add(i);
            }

            var hourList = new List<int>();
            for (int i = 0; i < 24; i++)
            {
                hourList.Add(i);
            }

            var minuteList = new List<int>();
            for (int i = 0; i < 60; i++)
            {
                minuteList.Add(i);
            }

            var model = new HarmonicPatternCreateViewModel
            {
                Day = DateTime.Now.Day,
                Month = DateTime.Now.Month,
                Year = DateTime.Now.Year,
                Hour = DateTime.Now.Hour,
                Minute = DateTime.Now.Minute,

                DayList = new SelectList(dayList),
                MonthList = new SelectList(monthList),
                YearList = new SelectList(yearList),
                HourList = new SelectList(hourList),
                MinuteList = new SelectList(minuteList),
                IntervalList = new SelectList(_context.Intervals, "Id", "Name"),
                PatternTypeList = new SelectList(_context.Patterns, "Id", "Name"),
                InstrumentList = new SelectList(_context.Instruments, "Id", "Name"),
                PatternDirectList = new SelectList(_context.PatternDirects, "Id", "Name"),
            };

            return View(model);
        }

        // POST: HarmonicPatterns/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HarmonicPatternCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var harmonicPattern = new HarmonicPattern
                {
                    Date = new DateTime(model.Year, model.Month, model.Day, model.Hour, model.Minute, 0),
                    AddDate = DateTime.Now,
                    Discription = model.Discription,
                    Image = new byte[1],
                    PatternTypeId = model.PatternTypeId,
                    IntervalId = model.IntervalId,
                    InstrumentId = model.InstrumentId,
                    PatternDirectId = model.PatternDirectId                 
                };
                _context.Add(harmonicPattern);
                await _context.SaveChangesAsync();
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
