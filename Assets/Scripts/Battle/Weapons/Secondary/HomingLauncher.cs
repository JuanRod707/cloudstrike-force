using Common;
using UnityEngine;

namespace Assets.Scripts.Battle.Weapons.Secondary
{
    public class HomingLauncher : Weapon
    {
        public HomingProjectile Missile;
        public Transform[] FiringPositions;
        public LayerMask TargetLayer;
        public float LockTime;

        protected override void FireRound(Vector3 _, Transform target)
        {
            var missile = Instantiate(Missile, FiringPositions.PickOne().position, transform.rotation);
            missile.Launch(target, DamageMessage.Create(Stats.Damage, Stats.DamageTypes));
        }
        
       
    }
}
