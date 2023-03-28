using System;
using Cysharp.Threading.Tasks;
using Data.DataSource.RemoteDataSource.API;
using UnityEngine;

namespace Data.DataSource.RemoteDataSource
{
    public class RemoteTimeDataSource : IRemoteTimeDataSource
    {
        private readonly IRemoteTimeDataSource[] _apiDataSources = new IRemoteTimeDataSource[]
        {
            new TimeApiDataSource(),
            new WorldTimeApiDataSource()
        };
        
        public async UniTask TryGetDateTimeAsync(Action<DateTime> callback)
        {
            try
            {
                await UniTask.WhenAll(_apiDataSources.Select(dataSource =>
                    dataSource.TryGetDateTimeAsync(callback)));
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }
    }
}