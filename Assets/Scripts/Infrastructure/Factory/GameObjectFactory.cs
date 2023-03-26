using System;
using Infrastructure.Provider;
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

        public ClockView CreateClockView()
        {
            GameObject prefab = _assetProvider.Load(ResourcePaths.ClockViewPath);
            return GameObject.Instantiate(prefab).GetComponent<ClockView>() ??
                   throw new NullReferenceException("Prefab has no ClockView component");
        }
    }
}