using System;
using Cysharp.Threading.Tasks;
using Data.DataSource.LocalTimeDataSource;
using Data.DataSource.RemoteDataSource;
using Data.Repository;

namespace Domain.TimeProvider
{
    public class CurrentTimeProvider : ICurrentTimeProvider
    {
        private readonly ILocalTimeDataSource _localTimeDataSource;

        private readonly IRemoteTimeDataSource[] _remoteDataSources = new IRemoteTimeDataSource[]
        {
            new TimeApiRemoteDataSource(),
            new WorldTimeApiRemoteDataSource()
        };

        private TimeRepository _timeRepository;

        public CurrentTimeProvider(ILocalTimeDataSource localTimeDataSource)
        {
            _localTimeDataSource = localTimeDataSource;
            ObserveLocalTimeDataSource();
        }

        public DateTime CurrentTime { get; private set; }

        public async UniTask Synchronize()
        {
            _timeRepository = null;

            while (_timeRepository == null)
            {
                await UniTask.WhenAll(
                    _remoteDataSources.Select(dataSource => dataSource.TryGetDateTime(UpdateSavedTime)));
            }

            _localTimeDataSource.Reset();
        }

        private void UpdateSavedTime(DateTime dateTime) =>
            _timeRepository = new TimeRepository(dateTime);

        private void ObserveLocalTimeDataSource() =>
            _localTimeDataSource.LocalPassed.Observe(OnTimeUpdated);

        private void OnTimeUpdated(TimeSpan localPassed)
        {
            CurrentTime = _timeRepository != null
                ? _timeRepository.SavedTime + localPassed
                : DateTime.Now;
        }
           
    }
}