using System;
using Domain.TimeProvider;
using Infrastructure.TimeService;

namespace Domain.Synchroniser
{
    public class CurrentTimeSynchronizer
    {
        private readonly ICurrentTimeProvider _currentTimeProvider;
        private readonly ITimeService _timeService;
        private readonly int _synchroniseIntervalMinutes;

        public CurrentTimeSynchronizer(ICurrentTimeProvider currentTimeProvider, ITimeService timeService,
            int synchroniseIntervalMinutes)
        {
            _currentTimeProvider = currentTimeProvider;
            _timeService = timeService;
            _synchroniseIntervalMinutes = synchroniseIntervalMinutes;

            ObserveOnTimeService();
        }

        private void ObserveOnTimeService() =>
            _timeService.MillisecondsPassed.Observe(OnTimeServiceUpdated);

        private void OnTimeServiceUpdated(float millisecondsPassed)
        {
            bool needToSynchronise = TimeSpan.FromMilliseconds(millisecondsPassed) >=
                                     TimeSpan.FromMinutes(_synchroniseIntervalMinutes);
            if (needToSynchronise)
                _currentTimeProvider.Synchronize();
        }
    }
}