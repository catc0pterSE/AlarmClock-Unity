#nullable enable
using System;
using System.Globalization;
using Data.DataSource.Dto.WebTImeDto;

namespace Data.DataSource.Mapper.WebTimeMapper
{
    public class TimeApiDtoToDateTimeMapper : IWebDtoToDateTimeMapper<TimeApiDto>
    {
        public DateTime MapDtoToDateTime(TimeApiDto dto) =>
            DateTime.Parse(dto.dateTime, new DateTimeFormatInfo(), DateTimeStyles.AdjustToUniversal) +
            TimeZoneInfo.Local.BaseUtcOffset;
    }
}