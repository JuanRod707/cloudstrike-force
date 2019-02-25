using Entities;
using UnityEngine;

namespace Weapons
{
    public class LockOnSystem
    {
        UnityEngine.Camera camera;
        
        public LockOnSystem(UnityEngine.Camera camera)
        {
            this.camera = camera;
        }
        
        public Transform ScanForTarget()
        {
            var scanRay = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(scanRay, out hit, 500f))
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