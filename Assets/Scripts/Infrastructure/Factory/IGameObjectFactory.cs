using Presentation.View;

namespace Infrastructure.Factory
{
    public interface IGameObjectFactory
    {
        public ClockView CreateClockView();
    }
}