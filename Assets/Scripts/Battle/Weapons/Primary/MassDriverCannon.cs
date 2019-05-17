using Battle.Weapons.Secondary;
using UnityEngine;

namespace Battle.Weapons.Primary
{
    public class MassDriverCannon : Weapon
    {
        public Rocket ProjectilePrefab;
        public ParticleSystem Muzzle;
        public Animator Animator;

        protected override void FireRound(Vector3 _, Transform __)
        {
            var shot = Instantiate(ProjectilePrefab, Muzzle.transform.position, transform.rotation);
            shot.Launch(DamageMessage.Create(Stats.Damage, Stats.DamageTypes));
            Animator.SetTrigger("Fire");
            Muzzle.Play();
            FireSfx.Play();
        }
    }
}
