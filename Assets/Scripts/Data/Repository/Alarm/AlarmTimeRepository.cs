using System.Reflection;
using Data.DataSource.Dto.TimeDto;
using Data.DataSource.Mapper.AlarmTimeMapper;
using UnityEngine;
using Time = Domain.Model.Time;

namespace Data.Repository.Alarm
{
    public class AlarmTimeRepository : IAlarmTimeRepository
    {
        private const string TimeJsonKey = "AlarmTime";
        private readonly ITimeToDtoMapper _timeToDtoMapper = new TimeToDtoMapper();
        private readonly IDtoToTimeMapper _dtoToTimeMapper = new DtoToTimeMapper();

        private Time _time;

        public Time GetTime()
        {
            if (_time != null)
                return _time;

            TimeDto dto = JsonUtility.FromJson<TimeDto>(PlayerPrefs.GetString(TimeJsonKey));
            return dto != null ? _dtoToTimeMapper.Map(dto) : new Time();
        }

        public void Save(Time time)
        {
            _time = time;
            PlayerPrefs.SetString(TimeJsonKey, JsonUtility.ToJson(_timeToDtoMapper.Map(time)));
        }
    }
}