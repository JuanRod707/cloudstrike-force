using Assets.Scripts.Battle.Weapons;
using Battle.Effects;
using Battle.Entities;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Battle.Weapons.Primary
{
    public class HitscanCannon : Weapon
    {
        public ParticleSystem Cannon;
        public float Inaccuracy;
        public LayerMask HitLayer;

        protected override void FireRound(Vector3 position, Transform _)
        {
            Cannon.transform.LookAt(AimAt(position));
            RaycastHit hit;

            if (Physics.Raycast(Cannon.transform.position, Cannon.transform.forward, out hit, Stats.Range, HitLayer))
            {
                var hitBox = hit.collider.GetComponent<HitBox>();
                if (hitBox)
                    hitBox.Damage(DamageMessage.Create(Stats.Damage, Stats.DamageTypes));

                var impactCollider = hit.collider.GetComponent<ColliderImpact>();
                if (impactCollider)
                    impactCollider.ImpactHit(hit);
            }
            
            Cannon.Play();
        }

        Vector3 AimAt(Vector3 target) => target + (Random.insideUnitSphere * Inaccuracy);
    }
}
