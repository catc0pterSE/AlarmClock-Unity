#nullable enable
using System;

namespace Data.DataSource.Mapper.WebTimeMapper
{
    public interface IWebDtoToDateTimeMapper<T> where T : class
    {
        public DateTime MapDtoToDateTime(T dto);
    }
}