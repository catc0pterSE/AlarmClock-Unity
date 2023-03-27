using System;

namespace Presentation.ViewModel.Converter.TimeToAngles
{
    public interface ITimeToArrowAnglesConverter
    {
        public float ConvertHours(float hours);
        public float ConvertMinutes(float minutes);
        public float ConvertSeconds(float seconds);
    }
}