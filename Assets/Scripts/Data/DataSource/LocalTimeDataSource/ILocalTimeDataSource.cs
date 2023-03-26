using System;
using Modules;

namespace Data.DataSource.LocalTimeDataSource
{
    public interface ILocalTimeDataSource
    {
        public LiveData<TimeSpan> LocalPassed { get; }
        public void Reset();
    }
}