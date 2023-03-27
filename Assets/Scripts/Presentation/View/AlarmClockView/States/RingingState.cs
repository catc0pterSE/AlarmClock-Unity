namespace Presentation.View.AlarmClockView.States
{
    public class RingingState : IAlarmClockState
    {
        private readonly AlarmClockView _alarmClockView;

        public RingingState(AlarmClockView alarmClockView)
        {
            _alarmClockView = alarmClockView;
        }

        public void OnAlarmButtonClicked()
        {
            _alarmClockView.MuteAlarm();
            _alarmClockView.EnterCurrentTimeDisplayingState();
        }
    }
}