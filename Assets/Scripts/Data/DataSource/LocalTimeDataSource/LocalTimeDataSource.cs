using System;
using Infrastructure.TimeService;
using Modules;

namespace Data.DataSource.LocalTimeDataSource
{
    public class LocalTimeDataSource : ILocalTimeDataSource
    {
        private readonly ITimeService _timeService;
        private readonly MutableLiveData<TimeSpan> _localPassed = new MutableLiveData<TimeSpan>();

        public LocalTimeDataSource(ITimeService timeService)
        {
            _timeService = timeService;
            ObserveTimeService();
        }

        public void Reset() =>
            _timeService.Reset();

        private void ObserveTimeService() =>
            _timeService.MillisecondsPassed.Observe(OnTimeUpdated);

        public LiveData<TimeSpan> LocalPassed => _localPassed;

        private void OnTimeUpdated(float millisecondsPassed) =>
            _localPassed.Value = TimeSpan.FromMilliseconds(millisecondsPassed);
    }
}