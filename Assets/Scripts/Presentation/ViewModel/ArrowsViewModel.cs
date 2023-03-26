using System;
using Domain.UseCase;
using Infrastructure.TimeService;
using Modules;
using Presentation.ViewModel.Converter;
using Presentation.ViewModel.Converter.TimeToAngles;

namespace Presentation.ViewModel
{
    public class ArrowsViewModel
    {
        private readonly ITimeService _timeService;
        private readonly GetCurrentTimeUseCase _getCurrentTimeUseCase;
        private readonly MutableLiveData<ArrowAngles> _arrowAngles = new MutableLiveData<ArrowAngles>();
        private readonly ITimeToArrowAnglesConverter _timeToArrowAnglesConverter =
            new SimpleTimeToArrowAnglesConverter();

        public ArrowsViewModel(ITimeService timeService, GetCurrentTimeUseCase getCurrentTimeUseCase)
        {
            _timeService = timeService;
            _getCurrentTimeUseCase = getCurrentTimeUseCase;
            ObserveTimeService();
        }

        public LiveData<ArrowAngles> ArrowAngles => _arrowAngles;

        private void ObserveTimeService() =>
            _timeService.MillisecondsPassed.Observe(OnTimeUpdated);

        public float HourArrowAngle { get; private set; }
        public float MinuteArrowAngle { get; private set; }
        public float SecondArrowAngle { get; private set; }

        private void OnTimeUpdated(float _)
        {
            DateTime currentTime = _getCurrentTimeUseCase.Invoke();
            _arrowAngles.Value = _timeToArrowAnglesConverter.Convert(currentTime);
        }
    }
}