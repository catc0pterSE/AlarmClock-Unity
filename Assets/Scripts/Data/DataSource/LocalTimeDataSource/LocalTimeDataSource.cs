using System;
using Infrastructure.Service.TimeService;
using Modules;
using Modules.LiveData;

namespace Data.DataSource.LocalTimeDataSource
{
    public class LocalTimeDataSource : ILocalTimeDataSource
    {
       private readonly MutableLiveData<TimeSpan> _localPassed = new MutableLiveData<TimeSpan>();
       public LiveData<TimeSpan> LocalPassed => _localPassed;

       public void Update(float millisecondsPassed) =>
           _localPassed.Value = TimeSpan.FromMilliseconds(millisecondsPassed);

       private void OnTimeUpdated(float millisecondsPassed) =>
            _localPassed.Value = TimeSpan.FromMilliseconds(millisecondsPassed);
    }
}