using UnityEngine;

namespace Weapons.Secondary
{
    public class Seeker : Weapon
    {
        public HomingProjectile Missile;
        public ParticleSystem Muzzle;
        public LayerMask TargetLayer;
        
        LockOnSystem lockOn;
        Transform lockedTarget;

        protected override void FireRound()
        {
            Muzzle.Play();
            var missile = Instantiate(Missile, Muzzle.transform.position, transform.rotation);
            missile.Launch(lockedTarget);
        }
        
        void Start() => lockOn = new LockOnSystem(UnityEngine.Camera.main, Stats.Range, TargetLayer);

        void Update()
        {
            if (lockedTarget == null)
            {
                lockedTarget = lockOn.ScanForTarget();
                if (lockedTarget != null)
                    Debug.Log($"Target locked");
            }
        }
    }
}
