using System;
using System.Collections.Generic;
using System.Linq;
using Battle.Effects;
using Battle.Entities;
using UnityEditorInternal;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Battle.Weapons.Primary
{
    public class GatlingGun : Weapon
    {
        public ParticleSystem Cannon;
        public float Inaccuracy;
        public LayerMask HitLayer;

        protected override void FireRound(Vector3 target)
        {
            Cannon.transform.LookAt(AimAt(target));
            RaycastHit hit;

            if (Physics.Raycast(Cannon.transform.position, Cannon.transform.forward, out hit, Stats.Range, HitLayer))
            {
                var hitBox = hit.collider.GetComponent<HitBox>();
                if (hitBox)
                    hitBox.Damage(Stats.Damage);

                var impactCollider = hit.collider.GetComponent<ColliderImpact>();
                if (impactCollider)
                    impactCollider.ImpactHit(hit);
            }
            
            Cannon.Play();
        }

        Vector3 AimAt(Vector3 target) => target + (Random.insideUnitSphere * Inaccuracy);
    }
}
