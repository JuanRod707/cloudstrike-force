using UnityEngine;

namespace Campaign.Cameras
{
    public class FollowObject : MonoBehaviour
    {
        public Transform Target;
        public float FollowSpeed;

        void Update() => transform.position = Vector3.Lerp(transform.position, Target.position, FollowSpeed);
    }
}
