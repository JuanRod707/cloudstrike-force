using Camera;
using UnityEngine;

namespace Player
{
    public class PlayerInitializer: MonoBehaviour
    {
        public ChaseCamera Camera;
        public CameraAnchors ShipAnchors;

        void Start()
        {
            Camera.SetCameraAnchors(ShipAnchors);
        }
    }
}
