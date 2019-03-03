using UnityEngine;

namespace Battle.Weapons.Secondary
{
    public class Seeker : Weapon
    {
        public HomingProjectile Missile;
        public ParticleSystem Muzzle;
        public LayerMask TargetLayer;
        public float LockTime;

        protected override void FireRound(Transform target)
        {
            Muzzle.Play();
            var missile = Instantiate(Missile, Muzzle.transform.position, transform.rotation);
            missile.Launch(target, Stats.Damage);
        }
        
       
    }
}
