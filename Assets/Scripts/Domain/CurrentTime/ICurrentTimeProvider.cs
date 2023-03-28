using Cysharp.Threading.Tasks;
using Domain.Model;

namespace Data.Repository.CurrentTime
{
    public interface ICurrentTimeProvider
    {
        public Time CurrentTime { get; }
    }
}