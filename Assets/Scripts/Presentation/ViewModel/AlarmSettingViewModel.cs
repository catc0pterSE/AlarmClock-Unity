using Data.UseCase;
using Domain.Model;
using Modules.LiveData;

namespace Presentation.ViewModel
{
    public class AlarmSettingViewModel
    {
        private readonly SaveAlarmTimeUseCase _saveAlarmTimeUseCase;
        private readonly GetAlarmTimeUseCase _getAlarmTimeUseCase;

        private MutableLiveData<Time> _alarmTime = new MutableLiveData<Time>();

        public AlarmSettingViewModel(GetAlarmTimeUseCase getAlarmTimeUseCase, SaveAlarmTimeUseCase saveAlarmTimeUseCase)
        {
            _saveAlarmTimeUseCase = saveAlarmTimeUseCase;
            _getAlarmTimeUseCase = getAlarmTimeUseCase;
        }

        public LiveData<Time> AlarmTime => _alarmTime;

        public void SetTimeWithAngles(float hoursArrowAngle, float minutesArrowsAngle, float secondsArrowsAngle) =>
            _alarmTime.Value = new Time(new TimeArrowAngles(hoursArrowAngle, minutesArrowsAngle, secondsArrowsAngle));

        public void SetTimeWithText(string hoursText, string minutesText, string secondsText) =>
            _alarmTime.Value = new Time(hoursText, minutesText, secondsText);

        public void Update() =>
            _alarmTime.Value = _getAlarmTimeUseCase.Invoke() ?? new Time();

        public void Save() =>
            _saveAlarmTimeUseCase.Invoke(_alarmTime.Value);
    }
}