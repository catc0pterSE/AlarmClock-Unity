using System;
using Cysharp.Threading.Tasks;

namespace Data.Repository.RemoteTime
{
    public interface IRemoteTimeRepository
    {
        public DateTime? RequestedTime { get; }
        public UniTask Synchronize();
    }
}