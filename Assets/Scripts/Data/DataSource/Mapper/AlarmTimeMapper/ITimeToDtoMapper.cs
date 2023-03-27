using Data.DataSource.Dto.TimeDto;
using Domain.Model;

namespace Data.DataSource.Mapper.AlarmTimeMapper
{
    public interface ITimeToDtoMapper
    {
        public TimeDto Map(Time time);

    }
}