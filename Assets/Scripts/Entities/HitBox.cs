using UnityEngine;

namespace Entities
{
    public class HitBox : MonoBehaviour
    {
        public Health AttachedHealth;
        public float DamageMultiplier = 1f;

        public void Damage(int damage) => AttachedHealth.ReceiveDamage((int)(damage * DamageMultiplier));
    }
}