using System;
using Modules;

namespace Infrastructure.TimeService
{
    public interface ITimeService
    {
        public LiveData<float> MillisecondsPassed { get; }
        public void Reset();
    }
}