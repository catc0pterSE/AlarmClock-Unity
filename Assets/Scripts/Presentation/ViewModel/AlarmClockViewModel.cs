using System;
using Data.Repository.CurrentTime;
using Data.UseCase;
using Infrastructure.Service.TimeService;

namespace Presentation.ViewModel
{
    public class AlarmClockViewModel
    {
        private readonly ICurrentTimeProvider _currentTimeProvider;
        private readonly GetAlarmTimeUseCase _getAlarmTimeUseCase;
        private readonly ITimeService _timeService;

        public AlarmClockViewModel(ICurrentTimeProvider currentTimeProvider, GetAlarmTimeUseCase getAlarmTimeUseCase,
            ITimeService timeService)
        {
            _currentTimeProvider = currentTimeProvider;
            _getAlarmTimeUseCase = getAlarmTimeUseCase;
            _timeService = timeService;
            SubscribeOnTimeService();
        }

        ~AlarmClockViewModel() =>
            UnsubscribeFromTimeService();

        public event Action AlarmTimeReached;

        private void SubscribeOnTimeService() =>
            _timeService.CurrentTimeepositoryUpdated += OnTimeChanged;

        private void UnsubscribeFromTimeService() =>
            _timeService.CurrentTimeepositoryUpdated -= OnTimeChanged;

        private void OnTimeChanged()
        {
            if (_currentTimeProvider.CurrentTime == _getAlarmTimeUseCase.Invoke())
                AlarmTimeReached?.Invoke();
        }
    }
}