using Battle.Entities.Control;
using Battle.Entities.Vehicles;
using Battle.UI;
using UnityEngine;

namespace Battle.Cloudstrike
{
    public class PlayerGameInput : MonoBehaviour, Controller
    {
        public Vehicle Ship;
        public float DeadZone;
        public LayerMask LockingLayer;
        public LockOnCrosshair LockOnTarget;
        public float LockingTime;

        Transform lockedTarget;
        private Vector3 screenCenter;
        private TargetSystem targetSystem;

        void FixedUpdate()
        {
            if(Input.GetButton("Fire1"))
                Ship.Weapons.FirePrimary(targetSystem.AimMouseTo(Input.mousePosition, Ship.Weapons.PrimaryStats.Range));

            if (Input.GetButtonDown("Fire2"))
                Ship.Weapons.FireSecondary(lockedTarget);

            if (Input.GetKey(KeyCode.E))
                Ship.Movement.IncreaseThrust();

            if (Input.GetKey(KeyCode.Q))
                Ship.Movement.DecreaseThrust();

            var mCoord = Input.mousePosition;
            var resultSteer = screenCenter - mCoord;
            
            if (resultSteer.magnitude > DeadZone)
            {
                resultSteer.x *= -1;
                Ship.Movement.Steer(resultSteer);
            }
        }

        void Start()
        {
            screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
            targetSystem = new TargetSystem(Camera.main, LockingLayer);
            Ship.Initialize(this);
        }

        public void Dock(Transform hangar)
        {
            enabled = false;
            Ship.Dock(hangar);
        }

        public void Undock()
        {
            enabled = true;
            Ship.Undock();
        }

        void Update()
        {
            lockedTarget = targetSystem.ScanForTarget(Ship.Weapons.SecondaryStats.Range, LockingTime);

            if (lockedTarget != null)
                LockOnTarget.LockOn(lockedTarget);
            else
                LockOnTarget.Disengage();
        }

        public void Disable() => enabled = false;

        public void ShootDown()
        {
            Disable();
            Ship.Destroy();
        }

        public void Enable() => enabled = true;
    }
}
