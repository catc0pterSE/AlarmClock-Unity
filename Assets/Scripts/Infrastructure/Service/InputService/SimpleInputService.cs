using UnityEngine;

namespace Infrastructure.Service.InputService
{
    public class SimpleInputService : IInputService
    {
        public Vector3 CurrentPointerPosition => Input.mousePosition;
    }
}