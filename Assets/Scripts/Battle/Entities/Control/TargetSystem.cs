using UnityEngine;

namespace Battle.Entities.Control
{
    public class TargetSystem
    {
        private Camera camera;
        private readonly LayerMask lockingLayer;

        private Transform previousLock;
        private Transform currentLock;
        private Transform definitiveLock;

        private float elapsedLockTime;

        public TargetSystem(Camera camera, LayerMask lockingLayer)
        {
            this.camera = camera;
            this.lockingLayer = lockingLayer;
        }

        public Vector3 AimMouseTo(Vector2 mousePoistion, float  aimDistance)
        {
            var viewRay = camera.ScreenPointToRay(mousePoistion);
            return viewRay.GetPoint(aimDistance);
        }

        public Transform ScanForTarget(float targetDistance, float lockTime)
        {
            previousLock = currentLock;
            Scan(targetDistance);
            Process(lockTime);

            return definitiveLock;
        }

        void Scan(float targetDistance)
        {
            var scanRay = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(scanRay, out hit, targetDistance, lockingLayer))
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

        void Process(float lockTime)
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
