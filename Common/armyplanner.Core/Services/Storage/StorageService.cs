using armyplanner.Core.Exceptions;
using armyplanner.Core.Interfaces;
using armyplanner.Core.Models.StorageService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace armyplanner.Core.Services.Storage
{
    public class StorageService : IStorageService
    {
        #region properties

        private readonly ILoggingService _loggingService;
        private readonly INetworkService _networkService;
        private readonly IConfigService _configService;

        /// <summary>
        /// 
        /// </summary>
        private string _storageServer = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        private bool _isConnected => this._networkService.IsConnected();

        #endregion

        #region constructors

        /// <summary>
        /// 
        /// </summary>
        public StorageService(ILoggingService loggingService,
            INetworkService networkService,
            IConfigService configService)
        {
            this._loggingService = loggingService ?? throw new ArgumentNullException(nameof(loggingService));
            this._networkService = networkService ?? throw new ArgumentNullException(nameof(networkService));
            this._configService = configService ?? throw new ArgumentNullException(nameof(configService));

            this.Initialize();
        }

        /// <summary>
        /// 
        /// </summary>
        ~StorageService()
        {

        }

        #endregion

        #region public methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="storageServer"></param>
        public void Initialize()
        {
            string storageServer = this._configService.Get("Storage:Server");
            this._storageServer = storageServer;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="force"></param>
        /// <returns></returns>
        public async Task<List<Game>> GetGamesAsync(bool force = false)
        {
            GamesIndex gamesIndex = await this.GetAsync<GamesIndex>("/games/index.json");

            return gamesIndex.Games;
        }

        #endregion

        #region private logic

        /// <summary>
        /// 
        /// </summary>
        private void VerifyStorageEnvironment()
        {
            if(string.IsNullOrEmpty(this._storageServer))
            {
                throw new ArgumentNullException("StorageServer-url is empty. check that the sService is initialized");
            }
        }

        /// <summary>
        /// add the required http-client header like bearer-auth, etc.
        /// </summary>
        private HttpClient CreateHttpClient()
        {
            this.VerifyStorageEnvironment();

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(this._storageServer);

            // clear the headers
            httpClient.DefaultRequestHeaders.Clear();

            return httpClient;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <returns></returns>
        private async Task<T> GetAsync<T>(string requestUrl)
        {
            if (!this._isConnected)
            {
                throw new NetworkNotConnectedException();
            }

            try
            {
                HttpClient httpClient = this.CreateHttpClient();

                string responseJson = await httpClient.GetStringAsync(requestUrl);
                T response = await Task.Run(() => JsonConvert.DeserializeObject<T>(responseJson));

                return response;
            }
            catch (Exception exception)
            {
                this._loggingService.LogException(exception, new Dictionary<string, string>
                {
                    { "requestUrl", requestUrl }
                });

                return default(T);
            }
        }

        #endregion
    }
}