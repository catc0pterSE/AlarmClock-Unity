namespace Presentation.View.AlarmClockView.States
{
    public class SettingAlarmState : IAlarmClockState
    {
        private readonly AlarmClockView _alarmClockView;

        public SettingAlarmState(AlarmClockView alarmClockView)
        {
            _alarmClockView = alarmClockView;
            _alarmClockView.StartSettingAlarm();
        }

        public void OnAlarmButtonClicked()
        {
            _alarmClockView.StopSettingAlarm();
            _alarmClockView.EnterCurrentTimeDisplayingState();
        }
    }
}