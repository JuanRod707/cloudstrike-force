using UnityEngine;

namespace Weapons.Secondary
{
    public class Seeker : Weapon
    {
        public HomingProjectile Missile;
        public ParticleSystem Muzzle;
        public float AimDistance;
        
        LockOnSystem lockOn;
        Transform lockedTarget;

        protected override void FireRound()
        {
            Muzzle.Play();
            var missile = Instantiate(Missile, Muzzle.transform.position, transform.rotation);
            missile.Launch(lockedTarget);
        }
        
        void Start() => lockOn = new LockOnSystem(UnityEngine.Camera.main);

        void Update() => lockedTarget = lockOn.ScanForTarget();
    }
}
