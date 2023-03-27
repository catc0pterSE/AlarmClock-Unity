using UnityEngine;

namespace Infrastructure.Service.InputService
{
    public interface IInputService
    {
        public Vector3 CurrentPointerPosition { get; }
    }
}