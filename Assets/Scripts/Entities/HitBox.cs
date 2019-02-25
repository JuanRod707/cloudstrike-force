using UnityEngine;

namespace Entities
{
    public class HitBox : MonoBehaviour
    {
        public Health AttachedHealth;

        public void Damage(int damage) => AttachedHealth.ReceiveDamage(damage);
    }
}