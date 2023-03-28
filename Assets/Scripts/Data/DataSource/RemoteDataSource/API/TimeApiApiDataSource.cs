#nullable enable
using Data.DataSource.Dto.WebTImeDto;
using Data.DataSource.Mapper.WebTimeMapper;
using Utility.Constants;

namespace Data.DataSource.RemoteDataSource
{
    public class TimeApiApiDataSource : ApiTimeDataSource<TimeApiDto>
    {
        public TimeApiApiDataSource() : base
        (
            new TimeApiDtoToDateTimeMapper(),
            ApiUrls.TimeApiUrl
        )
        {
        }
    }
}