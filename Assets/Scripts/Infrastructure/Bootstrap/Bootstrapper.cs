using Data.DataSource.LocalTimeDataSource;
using Data.Repository;
using Data.Repository.Alarm;
using Data.Repository.CurrentTime;
using Data.UseCase;
using Domain.Synchroniser;
using Infrastructure.Factory;
using Infrastructure.Provider;
using Infrastructure.Service.InputService;
using Infrastructure.Service.TimeService;
using Presentation.View;
using Presentation.ViewModel;
using UnityEngine;
using Utility.Extensions;

namespace Infrastructure.Bootstrap
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private int _synchronizeIntervalMinutes = 60;

        private void Awake() =>
            BootApp();

        private void BootApp()
        {
            IAssetProvider assetProvider = new AssetProvider();
            IGameObjectFactory gameObjectFactory = new GameObjectFactory(assetProvider);
            ITimeService timeService = new TimeService();
            ILocalTimeDataSource localTimeDataSource = new LocalTimeDataSource(timeService);
            ICurrentTimeRepository currentTimeRepository = new CurrentTimeRepository(localTimeDataSource);
            CurrentTimeSynchronizer currentTimeSynchronizer =
                new CurrentTimeSynchronizer(currentTimeRepository, timeService, _synchronizeIntervalMinutes);
            CurrentTimeDisplayingViewModel currentTimeDisplayingViewModel =
                new CurrentTimeDisplayingViewModel(timeService, new GetCurrentTimeUseCase(currentTimeRepository));
            IAlarmTimeRepository alarmTimeRepository = new AlarmTimeRepository();
            AlarmSettingViewModel alarmSettingViewModel = new AlarmSettingViewModel
            (
                new GetAlarmTimeUseCase(alarmTimeRepository),
                new SaveAlarmTimeUseCase(alarmTimeRepository)
            );
            IInputService inputService = new SimpleInputService();
            AlarmClockViewModel alarmClockViewModel = new AlarmClockViewModel(
                new GetCurrentTimeUseCase(currentTimeRepository),
                new GetAlarmTimeUseCase(alarmTimeRepository), timeService);
            AlarmClockView alarmClockView = gameObjectFactory.CreateAlarmClockView();
            alarmClockView.Construct(alarmClockViewModel, currentTimeDisplayingViewModel, alarmSettingViewModel,
                inputService);
            currentTimeRepository.Synchronize();
            alarmClockView.EnableObject();
        }
    }
}