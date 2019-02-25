using UnityEngine;

namespace Weapons.Secondary
{
    public class HomingProjectile : MonoBehaviour
    {
        public float Speed;
        public float TurnRate;
        public float Lifetime;
        
        Transform target;

        public void Launch(Transform target) => this.target = target;

        void Update()
        {
            transform.Translate(Vector3.forward * Speed);
            if(target != null)
                Steer();
        }

        void Steer()
        {
            var relativeTargetPosition = transform.InverseTransformPoint(target.position);
            var turnFactor = relativeTargetPosition.x > 0 ? 1f : -1f;
            
            transform.Rotate(Vector3.up * TurnRate * turnFactor, Space.World);
            
            turnFactor = relativeTargetPosition.y > 0 ? 1f : -1f;
            transform.Rotate(Vector3.right * TurnRate * turnFactor, Space.World);
        }
    }
}
