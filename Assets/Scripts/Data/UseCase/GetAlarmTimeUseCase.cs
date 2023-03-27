using System.Threading;
using Data.Repository;
using Data.Repository.Alarm;
using Domain.Model;

namespace Data.UseCase
{
    public class GetAlarmTimeUseCase
    {
        private readonly IAlarmTimeRepository _alarmTimeRepository;

        public GetAlarmTimeUseCase(IAlarmTimeRepository alarmTimeRepository)
        {
            _alarmTimeRepository = alarmTimeRepository;
        }

        public Time Invoke() =>
            _alarmTimeRepository.GetTime();
    }
}