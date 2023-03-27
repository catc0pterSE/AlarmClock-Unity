using Utility.Constants;

namespace Presentation.ViewModel.Converter.AnglesToTime
{
    public class SimpleAnglesToTimeConverter : IAnglesToTimeConverter
    {
        private const float OneHourAngle = (float)NumericConstants.MaxAngle / NumericConstants.HoursOnClockFace;
        private const float OneMinuteAngle = (float)NumericConstants.MaxAngle / NumericConstants.MinutesInHour;
        private const float OneSecondAngle = (float)NumericConstants.MaxAngle / NumericConstants.SecondsInMinute;


        public float ConvertHourArrowAngle(float angle) =>
            angle / OneHourAngle;

        public float ConvertMinuteArrowAngle(float angle) =>
            angle / OneMinuteAngle;

        public float ConvertSecondArrowAngle(float angle) =>
            angle / OneSecondAngle;
    }
}