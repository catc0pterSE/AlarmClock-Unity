#nullable enable
using System;
using Cysharp.Threading.Tasks;
using Data.TimeMapper;
using Network;
using UnityEngine;

namespace Data.DataSource.RemoteDataSource
{
    public class RemoteTimeDataSource<T> : IRemoteTimeDataSource where T : class
    {
        private readonly Query _query = new Query();
        private readonly ITimeMapper<T> _mapper;
        private readonly string _url;

        protected RemoteTimeDataSource(ITimeMapper<T> mapper, string url)
        {
            _mapper = mapper;
            _url = url;
        }

        public async UniTask TryGetDateTime(Action<DateTime> callback)
        {
            string? json = await _query.GetJson(_url);
            

            if (string.IsNullOrEmpty(json))
                throw new NullReferenceException($"{GetType()} {_url} json is null ");

            T dto = JsonUtility.FromJson<T>(json);

            if (dto == null)
                throw new NullReferenceException($"{GetType()} {_url} dto is null ");
            
            callback.Invoke(_mapper.MapDtoToDateTime(dto));
        }
    }
}