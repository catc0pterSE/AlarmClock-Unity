using Data.DataSource.LocalTimeDataSource;
using Domain.Synchroniser;
using Domain.TimeProvider;
using Domain.UseCase;
using Infrastructure.Factory;
using Infrastructure.Provider;
using Infrastructure.TimeService;
using Presentation.View;
using Presentation.ViewModel;
using UnityEngine;

namespace Infrastructure.Bootstrap
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private int _synchronizeIntervalMinutes = 60;

        private void Awake()
        {
            BootApp();
        }

        private void BootApp()
        {
            IAssetProvider assetProvider = new AssetProvider();
            IGameObjectFactory gameObjectFactory = new GameObjectFactory(assetProvider);
            ITimeService timeService = new TimeService.TimeService();
            ILocalTimeDataSource localTimeDataSource = new LocalTimeDataSource(timeService);
            ICurrentTimeProvider currentTimeProvider = new CurrentTimeProvider(localTimeDataSource);
            CurrentTimeSynchronizer currentTimeSynchronizer =
                new CurrentTimeSynchronizer(currentTimeProvider, timeService, _synchronizeIntervalMinutes);
            ArrowsViewModel arrowsViewModel = new ArrowsViewModel(timeService, new GetCurrentTimeUseCase(currentTimeProvider));
            TextViewModel textViewModel = new TextViewModel(timeService, new GetCurrentTimeUseCase(currentTimeProvider));
            ClockView clockView = gameObjectFactory.CreateClockView();
            clockView.Construct(arrowsViewModel, textViewModel);
            currentTimeProvider.Synchronize();
        }
    }
}