using System.Collections;
using Battle.Effects;
using Battle.Entities;
using UnityEngine;

namespace Battle.Weapons.Secondary
{
    public class Warhead : MonoBehaviour
    {
        Rocket rocket;
        private DamageMessage damage;
        private bool isArmed;

        public void Initialize(Rocket rocket, DamageMessage damage, float armingTime)
        {
            this.damage = damage;
            this.rocket = rocket;
            StartCoroutine(WaitAndArm(armingTime));
        }

        IEnumerator WaitAndArm(float time)
        {
            yield return new WaitForSeconds(time);
            isArmed = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (isArmed)
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
}
