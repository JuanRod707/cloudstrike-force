using Entities;
using UnityEngine;

namespace Weapons
{
    public class LockOnSystem
    {
        UnityEngine.Camera camera;
        private readonly float targetDistance;
        private readonly LayerMask targetLayer;

        public LockOnSystem(UnityEngine.Camera camera, float targetDistance, LayerMask targetLayer)
        {
            this.camera = camera;
            this.targetDistance = targetDistance;
            this.targetLayer = targetLayer;
        }
        
        public Transform ScanForTarget()
        {
            var scanRay = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(scanRay, out hit, targetDistance, targetLayer))
            {
                var target = hit.collider.GetComponent<LockableTarget>();
                if (target != null)
                {
                    return target.transform;
                }
            }

            return null;
        }
    }
}