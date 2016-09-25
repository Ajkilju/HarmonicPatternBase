using HarmonicPatternsBase.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarmonicPatternsBaseTest
{
    public class Config
    {
        public readonly IServiceProvider ServiceProvider;

        public Config()
        {
            var services = new ServiceCollection();

            services
                .AddEntityFrameworkInMemoryDatabase()
                .AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase());

            ServiceProvider = services.BuildServiceProvider();

            SeedData.IntervalsInit(ServiceProvider);
            SeedData.PatternsInit(ServiceProvider);
            SeedData.InstrumentsInit(ServiceProvider);
            SeedData.PatternDirectInit(ServiceProvider);
            SeedData.ReactionLvlsInit(ServiceProvider);
            SeedData.HarmonicPatternsInit(ServiceProvider);
        }
    }
}
