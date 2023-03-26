using UnityEngine;

namespace Infrastructure.Provider
{
    public interface IAssetProvider
    {
        GameObject Load(string path);
    }
}