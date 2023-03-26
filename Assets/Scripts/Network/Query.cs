#nullable enable
using System;
using Cysharp.Threading.Tasks;
using UnityEngine.Networking;

namespace Network
{
    public class Query
    {
        public async UniTask<string?> GetJson(string url)
        {
            UnityWebRequest webRequest = await UnityWebRequest.Get(url).SendWebRequest();

            if (webRequest.result is not UnityWebRequest.Result.Success)
                throw new Exception($"{url} webrequest unsuccesfull");

            return webRequest.downloadHandler.text;
        }
    }
}