using System;
using Infrastructure.Provider;
using Presentation;
using Presentation.View;
using UnityEngine;
using Utility.Constants;

namespace Infrastructure.Factory
{
    public class GameObjectFactory : IGameObjectFactory
    {
        private readonly IAssetProvider _assetProvider;

        public GameObjectFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public AlarmClockView CreateAlarmClockView()
        {
            GameObject prefab = _assetProvider.Load(ResourcePaths.AlarmClockViewPath);
            return GameObject.Instantiate(prefab).GetComponent<AlarmClockView>() ??
                   throw new NullReferenceException("Prefab has no AlarmClockView component");
        }
    }
}