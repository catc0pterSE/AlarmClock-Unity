using System;
using Modules;
using Modules.LiveData;

namespace Data.DataSource.LocalTimeDataSource
{
    public interface ILocalTimeDataSource
    {
        public LiveData<TimeSpan> LocalPassed { get; }
        public void Update(float millisecondsPassed);
    }
}