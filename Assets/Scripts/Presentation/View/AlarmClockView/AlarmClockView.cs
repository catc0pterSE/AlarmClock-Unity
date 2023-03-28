using Infrastructure.Service.InputService;
using Presentation.View.AlarmClockView.States;
using Presentation.View.AlarmSetting;
using Presentation.View.CurrentTimeDisplaying;
using Presentation.ViewModel;
using UnityEngine;
using UnityEngine.UI;
using Utility.Extensions;

namespace Presentation.View.AlarmClockView
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

            if (gameObject.activeSelf) 
                SubscribeOnViewModel();
        }

        private void OnEnable()
        {
            SubscribeOnAlarButton();
            SubscribeOnViewModel();
        }

        private void OnDisable()
        {
            UnsubscribeFromAlarButton();
            UnsubscribeFromViewModel();
        }
        
        private void SubscribeOnAlarButton()=>
            _alarmButton.onClick.AddListener(OnAlarmButtonClicked);

        private void UnsubscribeFromAlarButton() =>
            _alarmButton.onClick.RemoveListener(OnAlarmButtonClicked);

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
}