using Data.Repository.RequestedTime;

namespace Data.UseCase
{
    public class UpdateRemoteTypeUseCase
    {
        private readonly IRemoteTimeRepository _remoteTimeRepository;

        public UpdateRemoteTypeUseCase(IRemoteTimeRepository remoteTimeRepository)
        {
            _remoteTimeRepository = remoteTimeRepository;
        }

        public void Invoke() =>
            _remoteTimeRepository.Synchronize();
    }
}