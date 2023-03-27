namespace Presentation.ViewModel.Converter.AnglesToTime
{
    public interface IAnglesToTimeConverter
    {
        public float ConvertHourArrowAngle(float angle);
        public float ConvertMinuteArrowAngle(float angle);
        public float ConvertSecondArrowAngle(float angle);
    }
}