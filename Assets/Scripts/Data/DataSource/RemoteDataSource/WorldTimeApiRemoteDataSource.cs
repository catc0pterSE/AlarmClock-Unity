#nullable enable
using Data.TImeDto;
using Data.TimeMapper;

namespace Data.DataSource.RemoteDataSource
{
    public class WorldTimeApiRemoteDataSource : RemoteTimeDataSource<WorldTimeApiDto>
    {
        public WorldTimeApiRemoteDataSource() : base
        (
            new WorldTimeApiMapper(),
            "http://worldtimeapi.org/api/ETC/UTC"
        )
        {
        }
    }
}