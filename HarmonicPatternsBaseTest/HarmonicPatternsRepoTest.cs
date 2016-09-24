using HarmonicPatternsBase.Data;
using HarmonicPatternsBase.Models;
using HarmonicPatternsBase.Repositories;
using HarmonicPatternsBase.Repositories.Abstract;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace HarmonicPatternsBaseTest
{
    public class HarmonicPatternsRepoTest
    {
        private HarmonicPatternsRepo _harmonicPatternsRepo;
        private ApplicationDbContext _context;

        public HarmonicPatternsRepoTest()
        {
            Config config = new Config();
            _context = config.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            _harmonicPatternsRepo = new HarmonicPatternsRepo(_context);
        }

        [Fact]
        public async void AddHarmonicPatternToBaseTest()
        {
            HarmonicPattern hp = new HarmonicPattern
            {
                ABtoXAratio = 0,
                ADtoXAratio = 0,
                BCtoABratio = 0,
                CDtoABratio = 0,
                CDtoBCratio = 0,
                AddDate = DateTime.Now,
                Date = DateTime.Now,
                Discription = "test hp",
                Id = 1,
                Image = new byte[1],
                InstrumentId = 0,
                IntervalId = 0,
            };

            _harmonicPatternsRepo.AddHarmonicPattern(hp);
            _harmonicPatternsRepo.SaveChanges();
            var _hp = await _harmonicPatternsRepo.GetHarmonicPatternAsync(GetHarmonicPatternsMode.AsNoTracking, 1);
            Assert.Same(_hp.Discription, "test hp");
        }

    }
}
