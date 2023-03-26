using System;
using Cysharp.Threading.Tasks;

namespace Domain.TimeProvider
{
    public interface ICurrentTimeProvider
    {
        public DateTime CurrentTime { get; }
        public UniTask Synchronize();
    }
}