#nullable enable
using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Modules;
using UnityEngine;
using Utility.Constants;
using Utility.Extensions;

namespace Infrastructure.TimeService
{
    public class TimeService : ITimeService
    {
        private readonly MutableLiveData<float> _millisecondsPassed = new MutableLiveData<float>();
        private CancellationTokenSource? _destroyCancellation;

        public LiveData<float> MillisecondsPassed => _millisecondsPassed;

        ~TimeService() =>
            _destroyCancellation?.Cancel();

        public void Reset()
        {
            StopCount();
            _millisecondsPassed.Value = 0;
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
                _millisecondsPassed.Value += Time.unscaledDeltaTime * NumericConstants.MillisecondsInSecond;
            }
        }
    }
}