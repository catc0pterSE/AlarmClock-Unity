using System;
using Data.DataSource.LocalTimeDataSource;
using Data.UseCase;
using Infrastructure.Service.TimeService;

namespace Domain.Synchroniser
{
    public class CurrentTimeSynchronizer
    {
        private readonly UpdateRemoteTypeUseCase _updateRemoteTypeUseCase;
        private readonly ILocalTimeDataSource _localTimeDataSource;
        private readonly ITimeService _timeService;
        private readonly int _synchroniseIntervalMinutes;

        public CurrentTimeSynchronizer(UpdateRemoteTypeUseCase updateRemoteTypeUseCase,
            ILocalTimeDataSource localTimeDataSource, ITimeService timeService,
            int synchroniseIntervalMinutes)
        {
            _updateRemoteTypeUseCase = updateRemoteTypeUseCase;
            _localTimeDataSource = localTimeDataSource;
            _timeService = timeService;
            _synchroniseIntervalMinutes = synchroniseIntervalMinutes;

            ObserveLocalTimeDataService();
        }

        public void Synchronize()
        {
            _updateRemoteTypeUseCase.Invoke();
            _timeService.Reset();
        }

        private void ObserveLocalTimeDataService() =>
            _localTimeDataSource.LocalPassed.Observe(OnTimeServiceUpdated);

        private void OnTimeServiceUpdated(TimeSpan localPassed)
        {
            if (localPassed >= TimeSpan.FromMinutes(_synchroniseIntervalMinutes) == false)
                return;

            Synchronize();
        }
    }
}