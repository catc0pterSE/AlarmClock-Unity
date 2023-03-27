using Data.UseCase;
using Domain.Model;
using Infrastructure.Service.TimeService;
using Modules.LiveData;

namespace Presentation.ViewModel
{
    public class CurrentTimeDisplayingViewModel
    {
        private readonly ITimeService _timeService;
        private readonly GetCurrentTimeUseCase _getCurrentTimeUseCase;
        private MutableLiveData<Time> _time = new MutableLiveData<Time>();

        public CurrentTimeDisplayingViewModel(ITimeService timeService, GetCurrentTimeUseCase getCurrentTimeUseCase)
        {
            _timeService = timeService;
            _getCurrentTimeUseCase = getCurrentTimeUseCase;
            ObserveTimeService();
        }

        public LiveData<Time> Time => _time;

        private void ObserveTimeService() =>
            _timeService.MillisecondsPassed.Observe(OnTimeUpdated);

        private void OnTimeUpdated(float _) =>
            _time.Value = _getCurrentTimeUseCase.Invoke();
    }
}