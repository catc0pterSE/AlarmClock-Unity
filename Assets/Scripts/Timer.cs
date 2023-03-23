using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Model
{
    public class Timer : MonoBehaviour
    {
        private void Start()
        {
            Request();
        }


        private async void Request()
        {
            UnityWebRequest timeRequest = UnityWebRequest.Get("http://worldtimeapi.org/api/ETC/UTC");
            await timeRequest.SendWebRequest();
            Debug.Log(timeRequest.downloadHandler.text);

            TimeSpan a = new TimeSpan();
        }
    }
}
