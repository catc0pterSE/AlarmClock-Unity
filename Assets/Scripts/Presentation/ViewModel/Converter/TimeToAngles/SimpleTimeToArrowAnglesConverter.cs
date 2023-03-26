using System;
using Utility.Constants;

namespace Presentation.ViewModel.Converter.TimeToAngles
{
    public class SimpleTimeToArrowAnglesConverter : ITimeToArrowAnglesConverter
    {
        public ArrowAngles Convert(DateTime dateTime)
        {
            float seconds = dateTime.Second + (float)dateTime.Millisecond / NumericConstants.MillisecondsInSecond;
            float minutes = dateTime.Minute + seconds / NumericConstants.SecondsInMinute;
            float hours = dateTime.Hour - NumericConstants.HoursOnClockFace + minutes / NumericConstants.MinutesInHour;

            float hoursArrowAngle = hours * NumericConstants.MaxAngle / NumericConstants.HoursOnClockFace;
            float minutesArrowAngle = minutes * NumericConstants.MaxAngle / NumericConstants.MinutesInHour;
            float secondsArrowAngle = seconds * NumericConstants.MaxAngle / NumericConstants.SecondsInMinute;

            return new ArrowAngles(hoursArrowAngle, minutesArrowAngle, secondsArrowAngle);
        }
    }
}