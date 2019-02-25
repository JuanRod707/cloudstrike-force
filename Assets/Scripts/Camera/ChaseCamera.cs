using UnityEngine;

namespace Camera
{
    public class ChaseCamera : MonoBehaviour
    {
        public float PositionStiffness;
        public float ViewStiffness;

        private Transform viewTarget;
        private Transform positionTarget;

        public void SetCameraAnchors(CameraAnchors anchors)
        {
            viewTarget = anchors.CameraTarget;
            positionTarget = anchors.CameraPlacement;

            enabled = true;
        }

        void FixedUpdate()
        {
            transform.position = Vector3.Lerp(transform.position, positionTarget.position, PositionStiffness);
            transform.LookAt(viewTarget.position);
        }
    }
}
