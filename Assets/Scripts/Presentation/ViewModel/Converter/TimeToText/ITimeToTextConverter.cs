using System;

namespace Presentation.ViewModel.Converter.TimeToText
{
    public interface ITimeToTextConverter
    {
        public string ConvertHours(int hours);
        public string ConvertMinutes(int minutes);
        public string ConvertSeconds(int seconds);
    }
}