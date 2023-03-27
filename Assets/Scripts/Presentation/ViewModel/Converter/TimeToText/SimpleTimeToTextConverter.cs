using System;

namespace Presentation.ViewModel.Converter.TimeToText
{
    public class SimpleTimeToTextConverter : ITimeToTextConverter
    {
        public string ConvertHours(int hours) =>
            hours.ToString().PadLeft(2, '0');

        public string ConvertMinutes(int minutes) =>
            minutes.ToString().PadLeft(2, '0');

        public string ConvertSeconds(int seconds) =>
            seconds.ToString().PadLeft(2, '0');
    }
}