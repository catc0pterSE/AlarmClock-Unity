using System;
using Presentation.ViewModel.Converter.AnglesToTime;
using Presentation.ViewModel.Converter.TextToTime;
using Presentation.ViewModel.Converter.TimeToAngles;
using Presentation.ViewModel.Converter.TimeToText;
using Utility.Constants;

namespace Domain.Model
{
    public class Time
    {
        private readonly ITimeToArrowAnglesConverter _timeToArrowAnglesConverter =
            new SimpleTimeToArrowAnglesConverter();

        private readonly ITimeToTextConverter _timeToTextConverter = new SimpleTimeToTextConverter();
        private readonly IAnglesToTimeConverter _anglesToTimeConverter = new SimpleAnglesToTimeConverter();
        private readonly ITextToNumberConverter _textToNumberConverter = new SimpleTextToNumberConverter();

        public Time(DateTime dateTime)
            : this(dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond)
        {
        }

        public Time(TimeSpan timeSpan) : this(timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds)
        {
        }

        public Time(TimeArrowAngles timeArrowAngles)
        {
            Hours = _anglesToTimeConverter.ConvertHourArrowAngle(timeArrowAngles.HoursArrowAngle);
            Minutes = _anglesToTimeConverter.ConvertMinuteArrowAngle(timeArrowAngles.MinutesArrowAngle);
            Seconds = _anglesToTimeConverter.ConvertSecondArrowAngle(timeArrowAngles.SecondsArrowAngle);
        }

        public Time(string hoursText, string minutesText, string secondsText)
        {
            Hours = _textToNumberConverter.Convert(hoursText);
            Minutes = _textToNumberConverter.Convert(minutesText);
            Seconds = _textToNumberConverter.Convert(secondsText);
        }

        private Time(int hours, int minutes, int seconds, int milliseconds)
        {
            Seconds = seconds + (float)milliseconds / NumericConstants.MillisecondsInSecond;
            Minutes = minutes + Seconds / NumericConstants.SecondsInMinute;
            int hour = hours >= NumericConstants.HoursOnClockFace
                ? hours - NumericConstants.HoursOnClockFace
                : hours;
            Hours = hour + Minutes / NumericConstants.MinutesInHour;
        }
        
        public Time(float hours, float minutes, float seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        public Time()
        {
            Hours = 0;
            Minutes = 0;
            Seconds = 0;
        }

        public float Hours { get; private set; }
        public float Minutes { get; private set; }
        public float Seconds { get; private set; }

        public string HoursText => _timeToTextConverter.ConvertHours((int)Hours);
        public string MinutesText => _timeToTextConverter.ConvertMinutes((int)Minutes);
        public string SecondsText => _timeToTextConverter.ConvertSeconds((int)Seconds);

        public float HourArrowAngle => _timeToArrowAnglesConverter.ConvertHours(Hours);
        public float MinuteArrowAngle => _timeToArrowAnglesConverter.ConvertMinutes(Minutes);
        public float SecondArrowAngle => _timeToArrowAnglesConverter.ConvertSeconds(Seconds);

        public bool IsTimeZero => Hours == 0 && Minutes == 0 && Seconds == 0;

        public static bool operator ==(Time time1, Time time2) =>
            time1?.SecondsText == time2?.SecondsText &&
            time1?.MinutesText == time2?.MinutesText &&
            time1?.HoursText == time2?.HoursText;

        public static bool operator !=(Time time1, Time time2) =>
            (time1 == time2) == false;
    }
}