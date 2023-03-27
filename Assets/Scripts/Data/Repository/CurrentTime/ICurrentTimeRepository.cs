using Cysharp.Threading.Tasks;
using Domain.Model;

namespace Data.Repository.CurrentTime
{
    public interface ICurrentTimeRepository
    {
        public Time CurrentTime { get; }
        public UniTask Synchronize();
    }
}