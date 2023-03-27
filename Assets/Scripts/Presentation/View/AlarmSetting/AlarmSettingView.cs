using Infrastructure.Service.InputService;
using Presentation.ViewModel;
using UnityEngine;
using Time = Domain.Model.Time;

namespace Presentation.View.AlarmSetting
{
    public class AlarmSettingView : MonoBehaviour
    {
        [SerializeField] private AlarmArrowDragRotator _hoursArrow;
        [SerializeField] private AlarmArrowDragRotator _minutesArrow;
        [SerializeField] private AlarmArrowDragRotator _secondsArrow;
        [SerializeField] private InputFieldValidator _hoursInputField;
        [SerializeField] private InputFieldValidator _minutesInputField;
        [SerializeField] private InputFieldValidator _secondsInputField;

        private AlarmSettingViewModel _alarmSettingViewModel;

        public void Construct(AlarmSettingViewModel alarmSettingViewModel, IInputService inputService)
        {
            _alarmSettingViewModel = alarmSettingViewModel;
            _alarmSettingViewModel.Update();
            _hoursArrow.Construct(inputService);
            _minutesArrow.Construct(inputService);
            _secondsArrow.Construct(inputService);
            ObserveViewModel();
        }

        private void OnEnable()
        {
            SubscribeOnArrows();
            SubscribeOnInputFields();
            _alarmSettingViewModel.Update();
        }

        private void OnDisable()
        {
            UnSubscribeFromArrows();
            UnSubscribeFromInputFields();
            _alarmSettingViewModel.Save();
        }

        private void SubscribeOnArrows()
        {
            _hoursArrow.Rotated += OnArrowsRotated;
            _minutesArrow.Rotated += OnArrowsRotated;
            _secondsArrow.Rotated += OnArrowsRotated;
        }

        private void SubscribeOnInputFields()
        {
            _hoursInputField.InputValidated += OnInputChanged;
            _minutesInputField.InputValidated += OnInputChanged;
            _secondsInputField.InputValidated += OnInputChanged;
        }

        private void UnSubscribeFromArrows()
        {
            _hoursArrow.Rotated -= OnArrowsRotated;
            _minutesArrow.Rotated -= OnArrowsRotated;
            _secondsArrow.Rotated -= OnArrowsRotated;
        }

        private void UnSubscribeFromInputFields()
        {
            _hoursInputField.InputValidated -= OnInputChanged;
            _minutesInputField.InputValidated -= OnInputChanged;
            _secondsInputField.InputValidated -= OnInputChanged;
        }

        private void ObserveViewModel() =>
            _alarmSettingViewModel.AlarmTime.Observe(OnAlarmTimeChanged);

        private void OnAlarmTimeChanged(Time time)
        {
            if (time == null)
                return;
            
            SetText(time.HoursText, time.MinutesText, time.SecondsText);
            RotateArrows(time.HourArrowAngle, time.MinuteArrowAngle, time.SecondArrowAngle);
        }

        private void SetText(string hoursText, string minutesText, string secondsText)
        {
            _hoursInputField.SetText(hoursText);
            _minutesInputField.SetText(minutesText);
            _secondsInputField.SetText(secondsText);
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

        private void OnArrowsRotated() =>
            _alarmSettingViewModel.SetTimeWithAngles(_hoursArrow.GetAngle(), _minutesArrow.GetAngle(), _secondsArrow.GetAngle());

        private void OnInputChanged() =>
            _alarmSettingViewModel.SetTimeWithText(_hoursInputField.Text, _minutesInputField.Text, _secondsInputField.Text);
    }
}