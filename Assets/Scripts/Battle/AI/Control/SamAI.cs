using Assets.Scripts.Battle.Entities;
using Assets.Scripts.Battle.Entities.Control;
using UnityEngine;

namespace Assets.Scripts.Battle.AI.Control
{
    public class SamAI : MonoBehaviour, Controller
    {
        public Turret Turret;
     
        public void Initialize() => Turret.Initialize(this);

        public void AimToTarget(Transform target)
        {
            if (enabled)
                Turret.Aiming.AimTo(target);
        }

        public void Attack(Transform target) => Turret.Weapons.FirePrimary(target.position, target);

        public void Disable() => enabled = false;

        public void ShootDown() => Turret.Destroy();

        public void Enable() => enabled = true;
    }
}
