using Effects;
using UnityEngine;

namespace Weapons.Primary
{
    public class GatlingGun : Weapon
    {
        public ParticleSystem Cannon;
        public float AimDistance;
        public float Inaccuracy;

        protected override void FireRound()
        {
            Cannon.transform.LookAt(AimPoint(Input.mousePosition));
            RaycastHit hit;

            if (Physics.Raycast(Cannon.transform.position, Cannon.transform.forward, out hit, Stats.Range))
            {
                var impactCollider = hit.collider.GetComponent<ColliderImpact>();
                if (impactCollider != null)
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
