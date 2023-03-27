using System;
using System.Threading;
using Data.UseCase;
using Infrastructure.Service.TimeService;
using UnityEngine;

namespace Presentation.ViewModel
{
    public class AlarmClockViewModel
    {
        private readonly GetCurrentTimeUseCase _getCurrentTimeUseCase;
        private readonly GetAlarmTimeUseCase _getAlarmTimeUseCase;
        private readonly ITimeService _timeService;

        public AlarmClockViewModel(GetCurrentTimeUseCase getCurrentTimeUseCase, GetAlarmTimeUseCase getAlarmTimeUseCase, ITimeService timeService)
        {
            _getCurrentTimeUseCase = getCurrentTimeUseCase;
            _getAlarmTimeUseCase = getAlarmTimeUseCase;
            _timeService = timeService;
            ObserveTimeService();
        }

        public event Action AlarmTimeReached;

        private void ObserveTimeService() =>
            _timeService.MillisecondsPassed.Observe(OnTimeChanged);

        private void OnTimeChanged(float _)
        {
           if (_getCurrentTimeUseCase.Invoke()==_getAlarmTimeUseCase.Invoke())
               AlarmTimeReached?.Invoke();
        }
    }
}