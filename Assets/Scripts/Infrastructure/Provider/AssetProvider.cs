using UnityEngine;

namespace Infrastructure.Provider
{
    public class AssetProvider : IAssetProvider
    {
        public GameObject Load(string path) =>
            Resources.Load<GameObject>(path);
    }
}