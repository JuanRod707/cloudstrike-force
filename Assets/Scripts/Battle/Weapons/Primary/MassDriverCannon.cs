using Battle.Effects;
using Battle.Entities;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Battle.Weapons.Primary
{
    public class MassDriverCannon : Weapon
    {
        public ParticleSystem Muzzle;
        public Animator Animator;

        protected override void FireRound(Vector3 _, Transform __)
        {
            Animator.SetTrigger("Fire");
            Muzzle.Play();
            FireSfx.Play();
        }
    }
}
