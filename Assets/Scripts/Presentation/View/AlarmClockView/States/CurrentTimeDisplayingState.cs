namespace Presentation.View.AlarmClockView.States
{
    public class CurrentTimeDisplayingState : IAlarmClockState
    {
        private readonly AlarmClockView _alarmClockView;

        public CurrentTimeDisplayingState(AlarmClockView alarmClockView)
        {
            _alarmClockView = alarmClockView;
            _alarmClockView.DisplayCurrentTime();
        }

        public void OnAlarmButtonClicked()
        {
            _alarmClockView.HideCurrentTime();
            _alarmClockView.EnterSettingAlarmState();
        }
    }
}