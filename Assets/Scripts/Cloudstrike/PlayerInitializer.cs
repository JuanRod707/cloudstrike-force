using Camera;
using UnityEngine;

namespace Cloudstrike
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
