#nullable enable
using Data.DataSource.Dto.WebTImeDto;
using Data.DataSource.Mapper.WebTimeMapper;
using Utility.Constants;

namespace Data.DataSource.RemoteDataSource
{
    public class WorldTimeApiApiDataSource : ApiTimeDataSource<WorldTimeApiDto>
    {
        public WorldTimeApiApiDataSource() : base
        (
            new WorldTimeApiDtoToDateTimeMapper(),
            ApiUrls.WorldTimeApiUrl
        )
        {
        }
    }
}