using UnityEngine;

namespace UI
{
    class LockOnCrosshair : MonoBehaviour
    {
        public AudioSource Notification;

        private Transform previousTarget;

        public void LockOn(Transform target)
        {
            var targetChanged = target != previousTarget;

            if (!gameObject.activeInHierarchy || targetChanged)
            {
                gameObject.SetActive(true);
                Notification.Play();
            }

            transform.position = UnityEngine.Camera.main.WorldToScreenPoint(target.position);
            previousTarget = target;
        }

        public void Disengage() => gameObject.SetActive(false);
    }
}
