using System;
using Data.DataSource.LocalTimeDataSource;
using Data.UseCase;
using Domain.Model;

namespace Domain.CurrentTime
{
    public class CurrentTimeProvider : ICurrentTimeProvider
    {
        private readonly ILocalTimeDataSource _localTimeDataSource;
        private readonly GetRemoteTimeUseCase _getRemoteTimeUseCase;

        public CurrentTimeProvider(ILocalTimeDataSource localTimeDataSource, GetRemoteTimeUseCase getRemoteTimeUseCase)
        {
            _localTimeDataSource = localTimeDataSource;
            _getRemoteTimeUseCase = getRemoteTimeUseCase;
            ObserveLocalTimeDataSource();
        }

        public Time CurrentTime { get; private set; }

        private void ObserveLocalTimeDataSource() =>
            _localTimeDataSource.LocalPassed.Observe(OnTimeUpdated);

        private void OnTimeUpdated(TimeSpan localPassed)
        {
            DateTime? savedRemoteTime = _getRemoteTimeUseCase.Invoke();
            CurrentTime = savedRemoteTime != null
                ? new Time((DateTime)savedRemoteTime + localPassed)
                : new Time(DateTime.Now);
        }
    }
}