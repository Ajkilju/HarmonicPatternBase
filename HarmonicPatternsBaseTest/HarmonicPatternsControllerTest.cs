using HarmonicPatternBase.Repositories;
using HarmonicPatternsBase.Controllers;
using HarmonicPatternsBase.Data;
using HarmonicPatternsBase.Models;
using HarmonicPatternsBase.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using HarmonicPatternsBase.Models.HarmonicPatternViewModels;

namespace HarmonicPatternsBaseTest
{
    public class HarmonicPatternsControllerTest
    {
        private readonly HarmonicPatternsRepo _harmonicPatternsRepo;
        private readonly StatisticsRepo _statisticsRepo;
        private readonly UsersRepo _usersRepo;
        private readonly ApplicationDbContext _context;

        public HarmonicPatternsControllerTest()
        {
            // ******************************* TODO: add Moq ************************************

            Config config = new Config();
            _context = config.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            _harmonicPatternsRepo = new HarmonicPatternsRepo(_context);
            _statisticsRepo = new StatisticsRepo(_context);
            _usersRepo = new UsersRepo(_context);
        }

        [Fact]
        public async void IndexNotNullReturnTest()
        {
            var hpController = new HarmonicPatternsController(null, _harmonicPatternsRepo, _statisticsRepo, _usersRepo);

            var result = await hpController.Index();

            Assert.NotNull(result);
        }

        [Fact]
        public async void IndexRestultModelTest()
        {
            var hpController = new HarmonicPatternsController(null, _harmonicPatternsRepo, _statisticsRepo, _usersRepo);
            var result = await hpController.Index(
                pageSize: 2,
                page: 2,
                sortOrder: 1,
                viewOrder: 2,
                dateSince: new DateTime(2014, 1, 1),
                dateTo: new DateTime(2015, 12, 30),
                addDateSince: new DateTime(2014, 2, 1),
                addDateTo: new DateTime(2015, 10, 10));

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<HarmonicPatternIndexViewModel>(viewResult.ViewData.Model);
            Assert.Equal(model.SortOrder, 1);
            Assert.Equal(model.ViewOrder, 2);
            Assert.Equal(model.DateSince, new DateTime(2014, 1, 1));
            Assert.Equal(model.DateTo, new DateTime(2015, 12, 30));
            Assert.Equal(model.AddDateSince, new DateTime(2014, 2, 1));
            Assert.Equal(model.AddDateTo, new DateTime(2015, 10, 10));
        }

    }
}
