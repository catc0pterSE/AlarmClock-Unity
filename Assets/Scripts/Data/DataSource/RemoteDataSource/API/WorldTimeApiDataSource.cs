#nullable enable
using Data.DataSource.Dto.WebTImeDto;
using Data.DataSource.Mapper.WebTimeMapper;
using Utility.Constants;

namespace Data.DataSource.RemoteDataSource.API
{
    public class WorldTimeApiDataSource : ApiTimeDataSource<WorldTimeApiDto>
    {
        public WorldTimeApiDataSource() : base
        (
            new WorldTimeApiDtoToDateTimeMapper(),
            ApiUrls.WorldTimeApiUrl
        )
        {
        }
    }
}