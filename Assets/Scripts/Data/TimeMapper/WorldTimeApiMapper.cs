#nullable enable
using System;
using System.Globalization;
using Data.TImeDto;

namespace Data.TimeMapper
{
    public class WorldTimeApiMapper : ITimeMapper<WorldTimeApiDto>
    {
        public DateTime MapDtoToDateTime(WorldTimeApiDto dto) =>
            DateTime.Parse(dto.datetime, new DateTimeFormatInfo(), DateTimeStyles.AdjustToUniversal) +
            TimeZoneInfo.Local.BaseUtcOffset;
    }
}