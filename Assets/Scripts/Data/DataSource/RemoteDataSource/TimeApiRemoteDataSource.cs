#nullable enable
using Data.DataSource.Dto.WebTImeDto;
using Data.DataSource.Mapper.WebTimeMapper;

namespace Data.DataSource.RemoteDataSource
{
    public class TimeApiRemoteDataSource : RemoteTimeDataSource<TimeApiDto>
    {
        public TimeApiRemoteDataSource() : base
        (
            new TimeApiDtoToDateTimeMapper(),
            "https://timeapi.io/api/_time/current/zone?timeZone=UTC"
        )
        {
        }
    }
}