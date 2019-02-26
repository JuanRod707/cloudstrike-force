using Entities;
using UnityEngine;

namespace Weapons
{
    public class LockOnSystem
    {
        UnityEngine.Camera camera;
        private readonly float targetDistance;
        private readonly LayerMask targetLayer;

        private Transform previousLock;
        private Transform currentLock;
        private Transform definitiveLock;

        private float elapsedLockTime;
        private float lockTime;

        public LockOnSystem(UnityEngine.Camera camera, float lockTime, float targetDistance, LayerMask targetLayer)
        {
            this.camera = camera;
            this.targetDistance = targetDistance;
            this.targetLayer = targetLayer;
            this.lockTime = lockTime;
        }
        
        public Transform ScanForTarget()
        {
            previousLock = currentLock;
            Scan();
            Process();

            return definitiveLock;
        }

        void Scan()
        {
            var scanRay = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(scanRay, out hit, targetDistance, targetLayer))
            {
                var target = hit.collider.GetComponent<LockableTarget>();
                if (target != null)
                {
                    currentLock = target.transform;
                }
                else
                    currentLock = null;
            }
            else
                currentLock = null;
        }

        void Process()
        {
            if (previousLock == currentLock)
            {
                elapsedLockTime += Time.fixedDeltaTime;
                if (elapsedLockTime > lockTime)
                    definitiveLock = currentLock;
            }
            else
            {
                elapsedLockTime = 0;
            }
        }
    }
}