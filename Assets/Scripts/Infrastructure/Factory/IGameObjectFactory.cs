using Presentation.View;

namespace Infrastructure.Factory
{
    public interface IGameObjectFactory
    {
        public AlarmClockView CreateAlarmClockView();
    }
}