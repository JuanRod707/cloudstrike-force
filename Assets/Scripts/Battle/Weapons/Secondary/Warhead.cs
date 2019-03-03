using Battle.Effects;
using Battle.Entities;
using UnityEngine;

namespace Battle.Weapons.Secondary
{
    public class Warhead : MonoBehaviour
    {
        Rocket rocket;
        private int damage;
        
        public void Initialize(Rocket rocket, int damage)
        {
            this.damage = damage;
            this.rocket = rocket;
        }

        private void OnTriggerEnter(Collider other)
        {
            var hitBox = other.GetComponent<HitBox>();
            if (hitBox)
            {
                hitBox.Damage(damage);
                rocket.Destroy();
            }
            else if (other.GetComponent<ColliderImpact>())
                rocket.Destroy();
        }
    }
}
