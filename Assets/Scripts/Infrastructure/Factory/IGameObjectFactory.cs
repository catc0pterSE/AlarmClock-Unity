using Presentation.View;
using Presentation.View.AlarmClockView;

namespace Infrastructure.Factory
{
    public interface IGameObjectFactory
    {
        public AlarmClockView CreateAlarmClockView();
    }
}