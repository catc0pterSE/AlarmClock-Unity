using Infrastructure.Service.InputService;
using Presentation.View.AlarmSetting;
using Presentation.View.CurrentTimeDisplaying;
using Presentation.ViewModel;
using UnityEngine;
using UnityEngine.UI;
using Utility.Extensions;

namespace Presentation.View
{
    public class AlarmClockView : MonoBehaviour
    {
        [SerializeField] private RingAnimatorFacade[] _ringAnimatorFacades;
        [SerializeField] private AudioSource _alarm;
        [SerializeField] private Button _alarmButton;
        [SerializeField] private CurrentTimeDisplayingView _currentTimeDisplayingView;
        [SerializeField] private AlarmSettingView _alarmSettingView;

        private IAlarmClockState _currentState;
        private AlarmClockViewModel _viewModel;

        public void Construct
        (
            AlarmClockViewModel alarmClockViewModel,
            CurrentTimeDisplayingViewModel currentTimeDisplayingViewModel,
            AlarmSettingViewModel alarmSettingViewModel,
            IInputService inputService
        )
        {
            _viewModel = alarmClockViewModel;
            _currentTimeDisplayingView.Construct(currentTimeDisplayingViewModel);
            _alarmSettingView.Construct(alarmSettingViewModel, inputService);
            EnterCurrentTimeDisplayingState();

            if (gameObject.activeSelf) //TODO: meh
                SubscribeOnViewModel();
        }

        private void OnEnable()
        {
            _alarmButton.onClick.AddListener(OnAlarmButtonClicked);
            SubscribeOnViewModel();
        }


        private void OnDisable()
        {
            _alarmButton.onClick.AddListener(OnAlarmButtonClicked);
            UnsubscribeFromViewModel();
        }


        private void SubscribeOnViewModel() =>
            _viewModel.AlarmTimeReached += OnAlarmTimeReached;

        private void UnsubscribeFromViewModel() =>
            _viewModel.AlarmTimeReached -= OnAlarmTimeReached;

        private void OnAlarmTimeReached()
        {
            PlayAlarm();
            EnterRingingAlarmState();
        }

        public void EnterCurrentTimeDisplayingState() =>
            _currentState = new CurrentTimeDisplayingState(this);

        public void EnterSettingAlarmState() =>
            _currentState = new SettingAlarmState(this);

        public void EnterRingingAlarmState() =>
            _currentState = new RingingState(this);

        private void OnAlarmButtonClicked() =>
            _currentState?.OnAlarmButtonClicked();

        public void DisplayCurrentTime() =>
            _currentTimeDisplayingView.EnableObject();

        public void HideCurrentTime() =>
            _currentTimeDisplayingView.DisableObject();

        public void StartSettingAlarm() =>
            _alarmSettingView.EnableObject();

        public void StopSettingAlarm() =>
            _alarmSettingView.DisableObject();


        public void PlayAlarm()
        {
            _ringAnimatorFacades.Map(facade => facade.PlayRingAnimation());
            _alarm.Play();
        }
           
        public void MuteAlarm()
        {
            _ringAnimatorFacades.Map(facade => facade.StopRingAnimation());
            _alarm.Stop();
        }
            
    }

    public class CurrentTimeDisplayingState : IAlarmClockState
    {
        private readonly AlarmClockView _alarmClockView;

        public CurrentTimeDisplayingState(AlarmClockView alarmClockView)
        {
            _alarmClockView = alarmClockView;
            _alarmClockView.DisplayCurrentTime();
        }

        public void OnAlarmButtonClicked()
        {
            _alarmClockView.HideCurrentTime();
            _alarmClockView.EnterSettingAlarmState();
        }
    }

    public class RingingState : IAlarmClockState
    {
        private readonly AlarmClockView _alarmClockView;

        public RingingState(AlarmClockView alarmClockView)
        {
            _alarmClockView = alarmClockView;
        }

        public void OnAlarmButtonClicked()
        {
            _alarmClockView.MuteAlarm();
            _alarmClockView.EnterCurrentTimeDisplayingState();
        }
    }

    public class SettingAlarmState : IAlarmClockState
    {
        private readonly AlarmClockView _alarmClockView;

        public SettingAlarmState(AlarmClockView alarmClockView)
        {
            _alarmClockView = alarmClockView;
            _alarmClockView.StartSettingAlarm();
        }

        public void OnAlarmButtonClicked()
        {
            _alarmClockView.StopSettingAlarm();
            _alarmClockView.EnterCurrentTimeDisplayingState();
        }
    }

    public interface IAlarmClockState
    {
        public void OnAlarmButtonClicked();
    }
}