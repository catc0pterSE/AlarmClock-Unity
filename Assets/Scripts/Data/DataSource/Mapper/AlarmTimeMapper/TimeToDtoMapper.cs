using Data.DataSource.Dto.TimeDto;
using Domain.Model;

namespace Data.DataSource.Mapper.AlarmTimeMapper
{
    public class TimeToDtoMapper : ITimeToDtoMapper
    {
        public TimeDto Map(Time time)
        {
            TimeDto dto = new TimeDto();
            dto.Hours = time.HoursText;
            dto.Minutes = time.MinutesText;
            dto.Seconds = time.SecondsText;
            return dto;
        }
    }
}