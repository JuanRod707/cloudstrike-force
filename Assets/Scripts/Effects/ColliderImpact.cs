using UnityEngine;

namespace Effects
{
    public class ColliderImpact : MonoBehaviour
    {
        public GameObject ImpactPrefab;

        public void ImpactHit(RaycastHit hit) => Instantiate(ImpactPrefab, hit.point, Quaternion.identity);
    }
}
