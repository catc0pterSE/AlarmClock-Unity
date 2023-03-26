using Presentation.ViewModel;
using Presentation.ViewModel.Converter;
using Presentation.ViewModel.Converter.TimeToAngles;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.View
{
    public class ClockView : MonoBehaviour
    {
        [SerializeField] private Image _hourArrow;
        [SerializeField] private Image _minuteArrow;
        [SerializeField] private Image _secondsArrow;
        [SerializeField] private TMP_Text _text;

        private ArrowsViewModel _arrowsViewModel;
        private TextViewModel _textViewModel;

        public void Construct(ArrowsViewModel arrowsViewModel, TextViewModel textViewModel)
        {
            _textViewModel = textViewModel;
            _arrowsViewModel = arrowsViewModel;
            ObserveArrowsViewModel();
            ObserveTextViewModel();
        }

        private void ObserveArrowsViewModel() =>
            _arrowsViewModel.ArrowAngles.Observe(OnArrowAnglesChanged);

        private void ObserveTextViewModel() =>
            _textViewModel.Text.Observe(OnTextChanged);

        private void OnTextChanged(string text) =>
            _text.text = text;

        private void OnArrowAnglesChanged(ArrowAngles arrowAngles)
        {
            Quaternion hourArrowRotation = Quaternion.Euler(0, 0, -arrowAngles.HoursArrowAngle);
            Quaternion minuteArrowRotation = Quaternion.Euler(0, 0, -arrowAngles.MinutesArrowAngle);
            Quaternion secondArrowRotation = Quaternion.Euler(0, 0, -arrowAngles.SecondsArrowAngle);

            _hourArrow.transform.rotation = hourArrowRotation;
            _minuteArrow.transform.rotation = minuteArrowRotation;
            _secondsArrow.transform.rotation = secondArrowRotation;
        }
    }
}