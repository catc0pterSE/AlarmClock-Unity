#nullable enable
using Data.TImeDto;
using Data.TimeMapper;

namespace Data.DataSource.RemoteDataSource
{
    public class TimeApiRemoteDataSource : RemoteTimeDataSource<TimeApiDto>
    {
        public TimeApiRemoteDataSource() : base
        (
            new TimeApiMapper(),
            "https://timeapi.io/api/Time/current/zone?timeZone=UTC"
        )
        {
        }
    }
}