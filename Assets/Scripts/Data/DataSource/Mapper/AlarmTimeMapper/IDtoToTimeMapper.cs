using Data.DataSource.Dto.TimeDto;
using Domain.Model;

namespace Data.DataSource.Mapper.AlarmTimeMapper
{
    public interface IDtoToTimeMapper
    {
        public Time Map(TimeDto dto);
    }
}