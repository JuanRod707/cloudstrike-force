using UnityEngine;

namespace Campaign.Cameras
{
    public class Zoom : MonoBehaviour
    {
        public float ZoomSensitivity;
        public Camera Camera;

        void Update()
        {
            if (Input.mouseScrollDelta.y > 0)
                Camera.fieldOfView += ZoomSensitivity;
            else if (Input.mouseScrollDelta.y < 0)
                Camera.fieldOfView -= ZoomSensitivity;
        }
    }
}
