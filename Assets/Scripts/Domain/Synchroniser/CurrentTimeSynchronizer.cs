using System;
using Data.Repository;
using Data.Repository.CurrentTime;
using Infrastructure.Service.TimeService;

namespace Domain.Synchroniser
{
    public class CurrentTimeSynchronizer
    {
        private readonly ICurrentTimeRepository _currentTimeRepository;
        private readonly ITimeService _timeService;
        private readonly int _synchroniseIntervalMinutes;

        public CurrentTimeSynchronizer(ICurrentTimeRepository currentTimeRepository, ITimeService timeService,
            int synchroniseIntervalMinutes)
        {
            _currentTimeRepository = currentTimeRepository;
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
                _currentTimeRepository.Synchronize();
        }
    }
}