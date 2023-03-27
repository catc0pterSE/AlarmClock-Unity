#nullable enable
using Data.DataSource.Dto.WebTImeDto;
using Data.DataSource.Mapper.WebTimeMapper;

namespace Data.DataSource.RemoteDataSource
{
    public class WorldTimeApiRemoteDataSource : RemoteTimeDataSource<WorldTimeApiDto>
    {
        public WorldTimeApiRemoteDataSource() : base
        (
            new WorldTimeApiDtoToDateTimeMapper(),
            "http://worldtimeapi.org/api/ETC/UTC"
        )
        {
        }
    }
}