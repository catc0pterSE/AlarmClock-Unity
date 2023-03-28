#nullable enable
using System;
using Cysharp.Threading.Tasks;

namespace Data.DataSource.RemoteDataSource
{
    public interface IRemoteTimeDataSource
    {
        public UniTask TryGetDateTimeAsync(Action<DateTime> callback);
    }
}