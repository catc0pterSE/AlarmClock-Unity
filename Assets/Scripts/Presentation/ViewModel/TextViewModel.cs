using System;
using Domain.UseCase;
using Infrastructure.TimeService;
using Modules;
using Presentation.ViewModel.Converter;
using Presentation.ViewModel.Converter.TimeToAngles;
using Presentation.ViewModel.Converter.TimeToText;

namespace Presentation.ViewModel
{
    public class TextViewModel
    {
        private readonly ITimeService _timeService;
        private readonly GetCurrentTimeUseCase _getCurrentTimeUseCase;
        private readonly MutableLiveData<string> _text = new MutableLiveData<string>();
        private readonly ITimeToTextConverter _timeToTextConverter = new SimpleTimeToTextConverter();

        private readonly ITimeToArrowAnglesConverter _timeToArrowAnglesConverter =
            new SimpleTimeToArrowAnglesConverter();

        public TextViewModel(ITimeService timeService, GetCurrentTimeUseCase getCurrentTimeUseCase)
        {
            _timeService = timeService;
            _getCurrentTimeUseCase = getCurrentTimeUseCase;
            ObserveTimeService();
        }

        public LiveData<string> Text => _text;

        private void ObserveTimeService() =>
            _timeService.MillisecondsPassed.Observe(OnTimeUpdated);

        public float HourArrowAngle { get; private set; }
        public float MinuteArrowAngle { get; private set; }
        public float SecondArrowAngle { get; private set; }

        private void OnTimeUpdated(float _)
        {
            DateTime currentTime = _getCurrentTimeUseCase.Invoke();
            _text.Value = _timeToTextConverter.Convert(currentTime);
        }
    }
}