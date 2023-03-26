using System;

namespace Presentation.ViewModel.Converter.TimeToText
{
    public class SimpleTimeToTextConverter : ITimeToTextConverter
    {
        public string Convert(DateTime dateTime)
        {
            string hours = dateTime.Hour.ToString().Length>1? $"{dateTime.Hour}": $"0{dateTime.Hour}";
            string minutes = dateTime.Minute.ToString().Length>1? $"{dateTime.Minute}": $"0{dateTime.Minute}";
            string seconds = dateTime.Second.ToString().Length>1? $"{dateTime.Second}": $"0{dateTime.Second}";

            return $"{hours}:{minutes}:{seconds}";
        }
           


    }
}