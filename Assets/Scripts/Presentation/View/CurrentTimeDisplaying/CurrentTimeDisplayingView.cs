using Presentation.ViewModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Time = Domain.Model.Time;

namespace Presentation.View.CurrentTimeDisplaying
{
    public class CurrentTimeDisplayingView : MonoBehaviour
    {
        [SerializeField] private Image _hoursArrow;
        [SerializeField] private Image _minutesArrow;
        [SerializeField] private Image _secondsArrow;
        [SerializeField] private TMP_Text _hoursText;
        [SerializeField] private TMP_Text _minutesText;
        [SerializeField] private TMP_Text _secondsText;

        private CurrentTimeDisplayingViewModel _currentTimeDisplayingViewModel;

        public void Construct(CurrentTimeDisplayingViewModel currentTimeDisplayingViewModel)
        {
            _currentTimeDisplayingViewModel = currentTimeDisplayingViewModel;
            ObserveViewModel();
        }

        private void ObserveViewModel() =>
            _currentTimeDisplayingViewModel.Time.Observe(OnTimeChanged);

        private void OnTimeChanged(Time time)
        {
            if (time == null)
                return;

            SetText(time.HoursText, time.MinutesText, time.SecondsText);
            RotateArrows(time.HourArrowAngle, time.MinuteArrowAngle, time.SecondArrowAngle);
        }


        private void SetText(string hoursText, string minutesText, string secondsText)
        {
            _hoursText.text = hoursText;
            _minutesText.text = minutesText;
            _secondsText.text = secondsText;
        }

        private void RotateArrows(float hoursArrowAngle, float minutesArrowAngle, float secondsArrowAngle)
        {
            Quaternion hoursArrowRotation = Quaternion.Euler(0, 0, -hoursArrowAngle);
            Quaternion minutesArrowRotation = Quaternion.Euler(0, 0, -minutesArrowAngle);
            Quaternion secondsArrowRotation = Quaternion.Euler(0, 0, -secondsArrowAngle);

            _hoursArrow.transform.rotation = hoursArrowRotation;
            _minutesArrow.transform.rotation = minutesArrowRotation;
            _secondsArrow.transform.rotation = secondsArrowRotation;
        }
    }
}