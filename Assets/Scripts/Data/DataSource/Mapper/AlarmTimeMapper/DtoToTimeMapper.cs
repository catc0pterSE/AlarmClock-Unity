using Data.DataSource.Dto.TimeDto;
using Domain.Model;

namespace Data.DataSource.Mapper.AlarmTimeMapper
{
    public class DtoToTimeMapper
    {
        public Time Map(TimeDto dto) =>
            new Time(dto.Hours, dto.Minutes, dto.Seconds);
    }
}