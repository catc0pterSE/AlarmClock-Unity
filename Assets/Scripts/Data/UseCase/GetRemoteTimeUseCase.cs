using System;
using Data.Repository.RequestedTime;

namespace Data.UseCase
{
    public class GetRemoteTimeUseCase
    {
        private readonly IRemoteTimeRepository _remoteTimeRepository;

        public GetRemoteTimeUseCase(IRemoteTimeRepository remoteTimeRepository)
        {
            _remoteTimeRepository = remoteTimeRepository;
        }

        public DateTime? Invoke() =>
            _remoteTimeRepository.RequestedTime;
    }
}