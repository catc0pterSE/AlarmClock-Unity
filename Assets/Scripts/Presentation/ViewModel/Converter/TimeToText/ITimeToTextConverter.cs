using System;

namespace Presentation.ViewModel.Converter.TimeToText
{
    public interface ITimeToTextConverter
    {
        public string Convert(DateTime dateTime);
    }
}