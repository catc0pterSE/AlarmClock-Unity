namespace Domain.Model
{
    public class TimeArrowAngles
    {
        public TimeArrowAngles(float hoursArrowAngle, float minutesArrowAngle, float secondsArrowAngle)
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