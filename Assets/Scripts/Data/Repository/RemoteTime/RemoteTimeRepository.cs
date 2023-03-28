using System;
using Cysharp.Threading.Tasks;
using Data.DataSource.RemoteDataSource;

namespace Data.Repository.RemoteTime
{
    public class RemoteTimeRepository : IRemoteTimeRepository
    {
        private readonly IRemoteTimeDataSource _remoteTimeDataSource;

        public RemoteTimeRepository(IRemoteTimeDataSource remoteTimeDataSource) =>
            _remoteTimeDataSource = remoteTimeDataSource;

        public DateTime? RequestedTime { get; private set; }

        public async UniTask Synchronize()
        {
            RequestedTime = null;

            while (RequestedTime == null)
            {
                await _remoteTimeDataSource.TryGetDateTimeAsync(UpdateRequestedTime);
            }
        }

        private void UpdateRequestedTime(DateTime dateTime) =>
            RequestedTime = dateTime;
    }
}