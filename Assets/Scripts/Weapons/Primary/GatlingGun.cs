using Effects;
using Entities;
using UnityEngine;

namespace Weapons.Primary
{
    public class GatlingGun : Weapon
    {
        public ParticleSystem Cannon;
        public float AimDistance;
        public float Inaccuracy;
        public LayerMask HitLayer;

        protected override void FireRound()
        {
            Cannon.transform.LookAt(AimPoint(Input.mousePosition));
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
            
            Cannon.Emit(1);
        }

        Vector3 AimPoint(Vector2 mousePoistion)
        {
            var viewRay = UnityEngine.Camera.main.ScreenPointToRay(mousePoistion);
            var range = viewRay.GetPoint(AimDistance);
            return range + (Random.insideUnitSphere * Inaccuracy);
        }
    }
}
