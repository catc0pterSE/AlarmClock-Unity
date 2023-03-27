using System;
using Infrastructure.Service.InputService;
using UnityEngine;
using UnityEngine.EventSystems;
using Utility.Constants;

namespace Presentation.View.AlarmSetting
{
    public class AlarmArrowDragRotator : MonoBehaviour, IDragHandler
    {
        private IInputService _inputService;

        public void Construct(IInputService inputService) =>
            _inputService = inputService;
        
        public event Action Rotated;

        public void OnDrag(PointerEventData eventData)
        {
            Transform arrowTransform = transform;
            arrowTransform.up = Input.mousePosition - arrowTransform.position;
            Rotated?.Invoke();
        }
        
        public float GetAngle()
        {
            Vector3 angles = transform.rotation.eulerAngles;
            return angles.z > 0 ? NumericConstants.MaxAngle - angles.z : -angles.z;
        }
    }
}