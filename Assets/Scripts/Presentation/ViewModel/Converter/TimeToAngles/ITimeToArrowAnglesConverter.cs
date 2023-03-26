using System;

namespace Presentation.ViewModel.Converter.TimeToAngles
{
    public interface ITimeToArrowAnglesConverter
    {
        public ArrowAngles Convert(DateTime dateTime);
    }
}