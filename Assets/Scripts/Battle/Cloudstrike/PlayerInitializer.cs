using Assets.Scripts.Battle.Cameras;
using UnityEngine;

namespace Assets.Scripts.Battle.Cloudstrike
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
