using UnityEngine;

namespace Presentation.View.AlarmClockView
{
    public class RingAnimatorFacade : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public void PlayRingAnimation() =>
            _animator.enabled = true;

        public void StopRingAnimation() =>
            _animator.enabled = false;

    }
}
