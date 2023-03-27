#nullable enable
using System;
using System.Globalization;
using Data.DataSource.Dto.WebTImeDto;

namespace Data.DataSource.Mapper.WebTimeMapper
{
    public class WorldTimeApiDtoToDateTimeMapper : IWebDtoToDateTimeMapper<WorldTimeApiDto>
    {
        public DateTime MapDtoToDateTime(WorldTimeApiDto dto) =>
            DateTime.Parse(dto.datetime, new DateTimeFormatInfo(), DateTimeStyles.AdjustToUniversal) +
            TimeZoneInfo.Local.BaseUtcOffset;
    }
}