#nullable enable
using Data.DataSource.Dto.WebTImeDto;
using Data.DataSource.Mapper.WebTimeMapper;
using Utility.Constants;

namespace Data.DataSource.RemoteDataSource.API
{
    public class TimeApiDataSource : ApiTimeDataSource<TimeApiDto>
    {
        public TimeApiDataSource() : base
        (
            new TimeApiDtoToDateTimeMapper(),
            ApiUrls.TimeApiUrl
        )
        {
        }
    }
}