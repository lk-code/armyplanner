using ArmyPlanner.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace ArmyPlanner.Core.Services.DataSet
{
    public class DataSetService : IDataSetService
    {
        #region properties

        private readonly ILoggingService _loggingService;

        #endregion

        #region constrcutors

        public DataSetService(ILoggingService loggingService)
        {
            this._loggingService = loggingService ?? throw new ArgumentNullException(nameof(loggingService));
        }

        #endregion

        #region logic

        public List<string> GetAvailableEntries()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
