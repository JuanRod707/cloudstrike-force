using UnityEngine;

namespace Assets.Scripts.Battle.Effects
{
    public class ColliderImpact : MonoBehaviour
    {
        public GameObject ImpactPrefab;

        public void ImpactHit(RaycastHit hit) => Instantiate(ImpactPrefab, hit.point, Quaternion.identity);
    }
}
