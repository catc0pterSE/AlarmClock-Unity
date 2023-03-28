using Data.DataSource.LocalTimeDataSource;
using Data.DataSource.RemoteDataSource;
using Data.Repository.Alarm;
using Data.Repository.CurrentTime;
using Data.Repository.RequestedTime;
using Data.UseCase;
using Domain.Synchroniser;
using Infrastructure.Factory;
using Infrastructure.Provider;
using Infrastructure.Service.InputService;
using Infrastructure.Service.TimeService;
using Presentation.View.AlarmClockView;
using Presentation.ViewModel;
using UnityEngine;
using Utility.Extensions;

namespace Infrastructure.Application.Bootstrap
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

            ILocalTimeDataSource localTimeDataSource = new LocalTimeDataSource();
            IRemoteTimeDataSource remoteTimeDataSource = new RemoteTimeDataSource();

            ITimeService timeService = new TimeService(localTimeDataSource);
            IInputService inputService = new SimpleInputService();

            IAlarmTimeRepository alarmTimeRepository = new AlarmTimeRepository();
            IRemoteTimeRepository remoteTimeRepository = new RemoteTimeRepository(remoteTimeDataSource);

            GetAlarmTimeUseCase getAlarmTimeUseCase = new GetAlarmTimeUseCase(alarmTimeRepository);
            SaveAlarmTimeUseCase saveAlarmTimeUseCase = new SaveAlarmTimeUseCase(alarmTimeRepository);
            GetRemoteTimeUseCase getRemoteTimeUseCase = new GetRemoteTimeUseCase(remoteTimeRepository);
            UpdateRemoteTypeUseCase updateRemoteTypeUseCase = new UpdateRemoteTypeUseCase(remoteTimeRepository);

            ICurrentTimeProvider currentTimeProvider =
                new CurrentTimeProvider(localTimeDataSource, getRemoteTimeUseCase);
            CurrentTimeSynchronizer currentTimeSynchronizer =
                new CurrentTimeSynchronizer(updateRemoteTypeUseCase, localTimeDataSource, timeService,
                    _synchronizeIntervalMinutes);

            CurrentTimeDisplayingViewModel currentTimeDisplayingViewModel =
                new CurrentTimeDisplayingViewModel(timeService, currentTimeProvider);
            AlarmSettingViewModel alarmSettingViewModel =
                new AlarmSettingViewModel(getAlarmTimeUseCase, saveAlarmTimeUseCase);
            AlarmClockViewModel alarmClockViewModel =
                new AlarmClockViewModel(currentTimeProvider, getAlarmTimeUseCase, timeService);

            AlarmClockView alarmClockView = gameObjectFactory.CreateAlarmClockView();
            alarmClockView.Construct(alarmClockViewModel, currentTimeDisplayingViewModel, alarmSettingViewModel,
                inputService);

            currentTimeSynchronizer.Synchronize();
            alarmClockView.EnableObject();
        }
    }
}