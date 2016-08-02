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
            var model = new HarmonicPatternIndexViewModel
            {
                HarmonicPatterns = await _harmonicPatternsRepo
                      .GetHarmonicPatternsAsync(GetHarmonicPatternsMode.AsNoTracking, intervalId, patternTypeId, instrumentId),
                Intervals = await _harmonicPatternsRepo.GetIntervalsAsync(GetIntervalsMode.AsNoTracking),
                PatternTypes = await _harmonicPatternsRepo.GetPatternTypesAsync(GetPatternTypesMode.AsNoTracking),
                Instruments = await _harmonicPatternsRepo.GetInstrumentsAsync(GetInstrumentTypesMode.AsNoTracking),

                SelectedInterval = await _harmonicPatternsRepo.GetIntervalAsync(GetIntervalsMode.AsNoTracking, intervalId),
                SelectedPattern = await _harmonicPatternsRepo.GetPatternTypeAsync(GetPatternTypesMode.AsNoTracking, patternTypeId),
                SelectedInstrument = await _harmonicPatternsRepo.GetInstrumentAsync(GetInstrumentTypesMode.AsNoTracking, instrumentId),

                
                SelectedPatternId = patternTypeId,
                SelectedIntervalId = intervalId,
                SelectedInstrumentId = instrumentId
                
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
            ViewData["IntervalId"] = new SelectList(_context.Intervals, "Id", "Name");
            ViewData["PatternTypeId"] = new SelectList(_context.Patterns, "Id", "Name");
            ViewData["InstrumentId"] = new SelectList(_context.Instruments, "Id", "Name");

            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");

            var model = new HarmonicPatternCreateViewModel
            {
                Day = DateTime.Now.Day,
                Month = DateTime.Now.Month,
                Year = DateTime.Now.Year,
                Hour = DateTime.Now.Hour,
                Minute = DateTime.Now.Minute
            };

            return View(model);
        }

        // POST: HarmonicPatterns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                    InstrumentId = model.InstrumentId
                };
                _context.Add(harmonicPattern);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["IntervalId"] = new SelectList(_context.Intervals, "Id", "Id", model.IntervalId);
            ViewData["PatternTypeId"] = new SelectList(_context.Patterns, "Id", "Id", model.PatternTypeId);
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
