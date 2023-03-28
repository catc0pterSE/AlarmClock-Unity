using Domain.Model;

namespace Domain.CurrentTime
{
    public interface ICurrentTimeProvider
    {
        public Time CurrentTime { get; }
    }
}