using UnityEngine;

namespace Weapons.Secondary
{
    public class HomingProjectile : MonoBehaviour
    {
        public float Speed;
        public float TurnRate;
        public float Lifetime;
        
        Transform target;

        public void Launch(Transform target)
        {
            Debug.Log($"launched with target null? {target == null}");
            this.target = target;
        }

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
            
            transform.Rotate(Vector3.up * TurnRate * turnFactor);
            
            turnFactor = relativeTargetPosition.y > 0 ? 1f : -1f;
            transform.Rotate(Vector3.right * TurnRate * turnFactor);

            Normalize();
        }

        void Normalize()
        {
            var eul = this.transform.eulerAngles;
            eul.z = 0f;
            this.transform.eulerAngles = eul;
        }
    }
}
