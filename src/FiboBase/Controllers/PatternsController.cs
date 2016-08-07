using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HarmonicPatternsBase.Repositories.Abstract;
using HarmonicPatternsBase.Models.PatternViewModels;
using HarmonicPatternsBase.Repositories;

namespace HarmonicPatternsBase.Controllers
{
    public class PatternsController : Controller
    {
        private readonly IHarmonicPatternsRepo _harmonicPatternsRepo;

        public PatternsController(IHarmonicPatternsRepo harmonicPatternsRepo)
        {
            _harmonicPatternsRepo = harmonicPatternsRepo;
        }

        public async Task<IActionResult> Index()
        {
            var model = new PatternsIndexViewModel
            {
                Patterns = await _harmonicPatternsRepo.GetPatternTypesAsync()
            };
            return View(model);
        }

        public async Task<IActionResult> Details(int Id)
        {
            var model = new PatternsDetailsViewModel
            {
                Pattern = await _harmonicPatternsRepo.GetPatternTypeAsync(Id)
            };
            return View(model);
        }
    }
}