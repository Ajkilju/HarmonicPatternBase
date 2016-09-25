using HarmonicPatternsBase.Data;
using HarmonicPatternsBase.Models;
using HarmonicPatternsBase.Repositories;
using HarmonicPatternsBase.Repositories.Abstract;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace HarmonicPatternsBaseTest
{
    public class HarmonicPatternsRepoTest
    {
        private readonly HarmonicPatternsRepo _harmonicPatternsRepo;
        private readonly ApplicationDbContext _context;

        public HarmonicPatternsRepoTest()
        {
            Config config = new Config();
            _context = config.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            _harmonicPatternsRepo = new HarmonicPatternsRepo(_context);
        }


        [Fact]
        public async void AddHarmonicPatternTest()
        {
            var hpList = await _harmonicPatternsRepo.GetHarmonicPatternsAsync(GetHarmonicPatternsMode.AsNoTracking);
            var count = hpList.Count;
            HarmonicPattern hp = new HarmonicPattern {  Discription = "test hp" };

            _harmonicPatternsRepo.AddHarmonicPattern(hp);
            _harmonicPatternsRepo.SaveChanges();

            var hpListAfterAdd = await _harmonicPatternsRepo.GetHarmonicPatternsAsync(GetHarmonicPatternsMode.AsNoTracking);
            var countAfterAdd = hpListAfterAdd.Count;

            Assert.Equal(count + 1, countAfterAdd);
        }

        [Fact]
        public async void GetHarmonicPatternsAsyncCountTest()
        {
            var hpList = await _harmonicPatternsRepo.GetHarmonicPatternsAsync(GetHarmonicPatternsMode.AsNoTracking, HowMany: 10);

            Assert.Equal(hpList.Count, 10);
        }
    }
}
