using System;
using Modules.LiveData;

namespace Infrastructure.Service.TimeService
{
    public interface ITimeService
    {
        public event Action CurrentTimeepositoryUpdated;
        public void Reset();
    }
}