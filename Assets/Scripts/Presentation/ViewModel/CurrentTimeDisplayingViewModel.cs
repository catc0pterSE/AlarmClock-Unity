using Data.Repository.CurrentTime;
using Domain.Model;
using Infrastructure.Service.TimeService;
using Modules.LiveData;

namespace Presentation.ViewModel
{
    public class CurrentTimeDisplayingViewModel
    {
        private readonly ITimeService _timeService;
        private readonly ICurrentTimeProvider _currentTimeProvider;
        private MutableLiveData<Time> _time = new MutableLiveData<Time>();

        public CurrentTimeDisplayingViewModel(ITimeService timeService, ICurrentTimeProvider currentTimeProvider)
        {
            _timeService = timeService;
            _currentTimeProvider = currentTimeProvider;
            SubscribeOnTimeService();
        }

        ~CurrentTimeDisplayingViewModel() =>
            UnsubscribeFromTimeService();
        
        public LiveData<Time> Time => _time;

        private void SubscribeOnTimeService() =>
            _timeService.CurrentTimeepositoryUpdated += OnTimeUpdated;
        
        private void UnsubscribeFromTimeService() =>
            _timeService.CurrentTimeepositoryUpdated -= OnTimeUpdated;
        
        private void OnTimeUpdated() =>
            _time.Value = _currentTimeProvider.CurrentTime;
    }
}