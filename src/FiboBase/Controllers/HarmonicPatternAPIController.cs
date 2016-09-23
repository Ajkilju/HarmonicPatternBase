using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HarmonicPatternsBase.Repositories.Abstract;
using HarmonicPatternsBase.Models;
using HarmonicPatternsBase.Repositories;

namespace HarmonicPatternsBase.Controllers
{
    [Produces("application/json")]
    [Route("api/hp")]
    public class HarmonicPatternAPIController : Controller
    {
        private IHarmonicPatternsRepo _harmonicPatternsRepo;

        public HarmonicPatternAPIController(IHarmonicPatternsRepo harmonicPatternsRepo)
        {
            _harmonicPatternsRepo = harmonicPatternsRepo;
        }

        [HttpGet]
        public async Task<List<HarmonicPattern>> Get()
        {
            return await _harmonicPatternsRepo.GetHarmonicPatternsAsync(GetHarmonicPatternsMode.AsNoTracking, HowMany:5);
        }

        [HttpGet("{id}")]
        public async Task<HarmonicPattern>Get(int id)
        {
            return await _harmonicPatternsRepo.GetHarmonicPatternAsync(GetHarmonicPatternsMode.AsNoTracking, id);
        }

        [HttpPost]
        public void Post(HarmonicPattern hp)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, HarmonicPattern hp)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}