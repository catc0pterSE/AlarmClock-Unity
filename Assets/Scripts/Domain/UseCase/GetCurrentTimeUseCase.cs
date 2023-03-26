using System;
using Domain.TimeProvider;

namespace Domain.UseCase
{
    public class GetCurrentTimeUseCase
    {
        private readonly ICurrentTimeProvider _currentTimeProvider;

        public GetCurrentTimeUseCase(ICurrentTimeProvider currentTimeProvider)
        {
            _currentTimeProvider = currentTimeProvider;
        }

        public DateTime Invoke() =>
            _currentTimeProvider.CurrentTime;
    }
}