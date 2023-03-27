using System;
using Utility.Constants;

namespace Presentation.ViewModel.Converter.TimeToAngles
{
    public class SimpleTimeToArrowAnglesConverter : ITimeToArrowAnglesConverter
    {
        public float ConvertHours(float hours) =>
            hours * NumericConstants.MaxAngle / NumericConstants.HoursOnClockFace;

        public float ConvertMinutes(float minutes) =>
            minutes * NumericConstants.MaxAngle / NumericConstants.MinutesInHour;

        public float ConvertSeconds(float seconds) =>
            seconds * NumericConstants.MaxAngle / NumericConstants.SecondsInMinute;
    }
}