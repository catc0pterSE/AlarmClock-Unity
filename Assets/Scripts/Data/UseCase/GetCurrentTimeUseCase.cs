using Data.Repository;
using Data.Repository.CurrentTime;
using Domain.Model;

namespace Data.UseCase
{
    public class GetCurrentTimeUseCase
    {
        private readonly ICurrentTimeRepository _currentTimeRepository;

        public GetCurrentTimeUseCase(ICurrentTimeRepository currentTimeRepository)
        {
            _currentTimeRepository = currentTimeRepository;
        }

        public Time Invoke() =>
            _currentTimeRepository.CurrentTime;
    }
}