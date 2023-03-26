#nullable enable
using System;
using System.Globalization;
using Data.TImeDto;

namespace Data.TimeMapper
{
    public class TimeApiMapper : ITimeMapper<TimeApiDto>
    {
        public DateTime MapDtoToDateTime(TimeApiDto dto) =>
            DateTime.Parse(dto.dateTime, new DateTimeFormatInfo(), DateTimeStyles.AdjustToUniversal) +
            TimeZoneInfo.Local.BaseUtcOffset;
    }
}