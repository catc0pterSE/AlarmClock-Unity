#nullable enable
using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Data.DataSource.LocalTimeDataSource;
using UnityEngine;
using Utility.Constants;

namespace Infrastructure.Service.TimeService
{
    public class TimeService : ITimeService
    {
        private readonly ILocalTimeDataSource _localTimeDataSource;
        private float _millisecondsPassed;
        private CancellationTokenSource? _destroyCancellation;

        public TimeService(ILocalTimeDataSource localTimeDataSource) =>
            _localTimeDataSource = localTimeDataSource;
        
        
        ~TimeService() =>
            _destroyCancellation?.Cancel();

        public event Action? CurrentTimeepositoryUpdated;

        public void Reset()
        {
            StopCount();
            _millisecondsPassed = 0;
            StartCount();
        }

        private void StopCount() =>
            _destroyCancellation?.Cancel();

        private void StartCount()
        {
            if (_destroyCancellation != null)
                _destroyCancellation.Dispose();

            _destroyCancellation = new CancellationTokenSource();

            Count(_destroyCancellation.Token);
        }

        private async UniTask Count(CancellationToken cancellationToken)
        {
            while (cancellationToken.IsCancellationRequested == false)
            {
                await UniTask.NextFrame();
                _millisecondsPassed += Time.unscaledDeltaTime * NumericConstants.MillisecondsInSecond;
                _localTimeDataSource.Update(_millisecondsPassed);
                CurrentTimeepositoryUpdated?.Invoke();
            }
        }
    }
}