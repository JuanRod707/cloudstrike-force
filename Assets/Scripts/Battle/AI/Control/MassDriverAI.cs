using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Battle.AI.Buildings;
using Battle.Entities;
using Battle.Entities.Control;
using UnityEngine;

namespace Battle.AI.Control
{
    public class MassDriverAI : MonoBehaviour, Controller
    {
        public Turret Turret;

        float rateOfFire;
        bool readyToFire;
        
        public void Initialize(float rateOfFire)
        {
            this.rateOfFire = rateOfFire;
            Turret.Initialize(this);
            StartCoroutine(Reload());
        }

        IEnumerator Reload()
        {
            readyToFire = false;
            yield return new WaitForSeconds(rateOfFire);
            readyToFire = true;
        }

        public void AimToClosestTarget(IEnumerable<Transform> targets)
        {
            if (enabled)
            {
                var target = targets.OrderBy(t => Vector3.Distance(transform.position, t.position)).FirstOrDefault();
                Turret.Aiming.AimTo(target);
                
                if (TargetIsInSight(target) && readyToFire)
                    Attack();
            }
        }

        bool TargetIsInSight(Transform target) => true;

        void Attack()
        {
            Turret.Weapons.FirePrimary(Vector3.zero, transform);
            StartCoroutine(Reload());
        }

        public void Disable()
        {
        }

        public void ShootDown()
        {
         
        }
    }
}