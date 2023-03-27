using Modules.LiveData;

namespace Infrastructure.Service.TimeService
{
    public interface ITimeService
    {
        public LiveData<float> MillisecondsPassed { get; }
        public void Reset();
    }
}