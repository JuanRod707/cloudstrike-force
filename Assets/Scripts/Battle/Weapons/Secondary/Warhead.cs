using System.Collections;
using Assets.Scripts.Battle.Effects;
using Assets.Scripts.Battle.Entities;
using UnityEngine;

namespace Assets.Scripts.Battle.Weapons.Secondary
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
