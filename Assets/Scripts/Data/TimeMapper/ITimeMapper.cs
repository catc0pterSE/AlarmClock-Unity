#nullable enable
using System;

namespace Data.TimeMapper
{
    public interface ITimeMapper<T> where T : class
    {
        public DateTime MapDtoToDateTime(T dto);
    }
}