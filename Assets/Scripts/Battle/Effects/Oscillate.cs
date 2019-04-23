using UnityEngine;

namespace Battle.Effects
{
    public class Oscillate : MonoBehaviour
    {
        public Vector3 Axis;

        public float Frequency;
        public float Amplitude;

        private float angle;

        void Update()
        {
            transform.Translate(Axis * Mathf.Sin(angle) * Amplitude);
            angle += Frequency;
        }
    }
}
