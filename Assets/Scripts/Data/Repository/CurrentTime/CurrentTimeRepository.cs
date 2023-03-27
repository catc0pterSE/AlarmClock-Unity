using System;
using Cysharp.Threading.Tasks;
using Data.DataSource.LocalTimeDataSource;
using Data.DataSource.RemoteDataSource;
using UnityEngine;
using Time = Domain.Model.Time;

namespace Data.Repository.CurrentTime
{
    public class CurrentTimeRepository : ICurrentTimeRepository
    {
        private readonly ILocalTimeDataSource _localTimeDataSource;

        private readonly IRemoteTimeDataSource[] _remoteDataSources = new IRemoteTimeDataSource[]
        {
            new TimeApiRemoteDataSource(),
            new WorldTimeApiRemoteDataSource()
        };

        private DateTime? _requestedTime;

        public CurrentTimeRepository(ILocalTimeDataSource localTimeDataSource)
        {
            _localTimeDataSource = localTimeDataSource;
            ObserveLocalTimeDataSource();
        }

        public Time CurrentTime { get; private set; }

        public async UniTask Synchronize()
        {
            _requestedTime = null;

            while (_requestedTime == null)
            {
                try
                {
                    await UniTask.WhenAll(_remoteDataSources.Select(dataSource =>
                        dataSource.TryGetDateTime(UpdateRequestedTime)));
                }
                catch (Exception e)
                {
                    Debug.Log(e.Message);
                }
            }

            _localTimeDataSource.Reset();
        }

        private void UpdateRequestedTime(DateTime dateTime) =>
            _requestedTime = dateTime;

        private void ObserveLocalTimeDataSource() =>
            _localTimeDataSource.LocalPassed.Observe(OnTimeUpdated);

        private void OnTimeUpdated(TimeSpan localPassed)
        {
            CurrentTime = _requestedTime != null
                ? new Time((DateTime)(_requestedTime + localPassed))
                : new Time(DateTime.Now);
        }
    }
}