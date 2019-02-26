using UI;
using UnityEngine;
using Camera = UnityEngine.Camera;

namespace Weapons.Secondary
{
    public class Seeker : Weapon
    {
        public HomingProjectile Missile;
        public ParticleSystem Muzzle;
        public LayerMask TargetLayer;
        public float LockTime;

        LockOnCrosshair LockOnTarget;
        
        LockOnSystem lockOn;
        Transform lockedTarget;

        protected override void FireRound()
        {
            Muzzle.Play();
            var missile = Instantiate(Missile, Muzzle.transform.position, transform.rotation);
            missile.Launch(lockedTarget, Stats.Damage);
        }
        
        void Start()
        {
            LockOnTarget = GameObject.Find("LockOnCrosshair").GetComponent<LockOnCrosshair>();
            lockOn = new LockOnSystem(UnityEngine.Camera.main, LockTime, Stats.Range, TargetLayer);
        }

        void Update()
        {
            lockedTarget = lockOn.ScanForTarget();

            if (lockedTarget != null)
                LockOnTarget.LockOn(lockedTarget);
            else
                LockOnTarget.Disengage();
        }
    }
}
