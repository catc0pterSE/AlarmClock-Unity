namespace Presentation.ViewModel.Converter.TimeToAngles
{
    public struct ArrowAngles
    {
        public ArrowAngles(float hoursArrowAngle, float minutesArrowAngle, float secondsArrowAngle)
        {
            HoursArrowAngle = hoursArrowAngle;
            MinutesArrowAngle = minutesArrowAngle;
            SecondsArrowAngle = secondsArrowAngle;
        }
        
        public float HoursArrowAngle { get; private set; }
        public float MinutesArrowAngle { get; private set; }
        public float SecondsArrowAngle { get; private set; }
    }
}