using System;

namespace Data.Repository
{
    public class TimeRepository
    {
        public TimeRepository(DateTime timeToSave)
        {
            SavedTime = timeToSave;
        }

        public DateTime SavedTime { get; }
    }
}