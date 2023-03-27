using Domain.Model;

namespace Data.Repository.Alarm
{
    public interface IAlarmTimeRepository
    {
        public Time GetTime();
        public void Save(Time time);
    }
}