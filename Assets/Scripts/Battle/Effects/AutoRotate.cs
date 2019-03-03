using UnityEngine;

namespace Battle.Effects
{
    public class AutoRotate : MonoBehaviour
    {
        public float RotationSpeed;
        public Vector3 Axis;

        void FixedUpdate() => transform.Rotate(Axis * RotationSpeed);
    }
}
