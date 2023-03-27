using Data.Repository;
using Data.Repository.Alarm;
using Domain.Model;

namespace Data.UseCase
{
    public class SaveAlarmTimeUseCase
    {
        private readonly IAlarmTimeRepository _alarmTimeRepository;

        public SaveAlarmTimeUseCase(IAlarmTimeRepository alarmTimeRepository)
        {
            _alarmTimeRepository = alarmTimeRepository;
        }

        public void Invoke(Time time) =>
            _alarmTimeRepository.Save(time);
    }
}