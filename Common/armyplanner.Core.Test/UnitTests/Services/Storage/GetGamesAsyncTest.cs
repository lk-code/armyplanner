using armyplanner.Core.Interfaces;
using armyplanner.Core.Models.StorageService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace armyplanner.Core.Test.UnitTests.Services.Storage
{
    [TestClass]
    public class GetGamesAsyncTest
    {
        [TestMethod]
        public async Task TestAvailibility()
        {
            // prepare
            IStorageService storageService = Startup.ServiceProvider.GetService<IStorageService>();

            // test
            try
            {
                List<Game> games = await storageService.GetGamesAsync();
                Assert.IsNotNull(games);
            } catch(Exception exception)
            {
                Assert.IsTrue(false);
            }
        }
    }
}