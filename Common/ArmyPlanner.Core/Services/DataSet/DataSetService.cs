using ArmyPlanner.Core.Interfaces;
using ArmyPlanner.Core.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ArmyPlanner.Core.Services.DataSet
{
    public class DataSetService : IDataSetService
    {
        #region properties

        private readonly ILoggingService _loggingService;

        private const string STORAGE_HOST = "https://armyplaner.blob.core.windows.net";

        #endregion

        #region constrcutors

        public DataSetService(ILoggingService loggingService)
        {
            this._loggingService = loggingService ?? throw new ArgumentNullException(nameof(loggingService));
        }

        #endregion

        #region logic

        public async Task<List<Game>> GetAvailableCodiziesAsync()
        {
            string gamesJsonUrl = "/games/index.json";
            JObject json = await this.GetJsonFromUrlAsync(gamesJsonUrl);
            JArray games = (JArray)json["games"];

            List<Game> gameResult = new List<Game>();

            foreach (var gameJson in games)
            {
                Game game = new Game
                {
                    Title = (string)gameJson["title"],
                    StoragePath = (string)gameJson["path"],
                    Codices = await this.GetCodiziesForGameAsync("/games" + (string)gameJson["path"])
                };

                gameResult.Add(game);
            }

            return gameResult;
        }

        public async Task<List<Codex>> GetCodiziesForGameAsync(string gamePath)
        {
            string gamesJsonUrl = gamePath + "/index.json";
            List<Codex> codexResult = new List<Codex>();

            try
            {
                JObject json = await this.GetJsonFromUrlAsync(gamesJsonUrl);
                JArray codices = (JArray)json["codices"];

                foreach (var codexJson in codices)
                {
                    Codex codex = new Codex
                    {
                        Name = (string)codexJson["title"],
                    };

                    codexResult.Add(codex);
                }
            } catch(Exception exception)
            {

            }

            return codexResult;
        }

        private async Task<JObject> GetJsonFromUrlAsync(string url)
        {
            HttpClient httpClient = await this.CreateHttpClientAsync();

            string responseJson = await httpClient.GetStringAsync(url);
            JObject json = JObject.Parse(responseJson);

            return json;
        }

        private async Task<HttpClient> CreateHttpClientAsync()
        {
            await Task.CompletedTask;

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(STORAGE_HOST);

            return httpClient;
        }

        #endregion
    }
}