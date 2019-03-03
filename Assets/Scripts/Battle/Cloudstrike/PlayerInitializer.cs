using Battle.Cameras;
using UnityEngine;

namespace Battle.Cloudstrike
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
