using Assets.Scripts.Battle.Entities.Control;
using Assets.Scripts.Battle.Entities.Vehicles;
using Assets.Scripts.Battle.UI;
using UnityEngine;

namespace Assets.Scripts.Battle.Cloudstrike
{
    public class PlayerGameInput : MonoBehaviour, Controller
    {
        public Vehicle ControlledPlane;
        public float DeadZone;
        public LayerMask LockingLayer;
        public float LockingTime;
        
        [Header("UI")]
        public LockOnCrosshair LockOnTarget;
        public BottomHud BottomHud;
        
        Transform lockedTarget;
        private Vector3 screenCenter;
        private TargetSystem targetSystem;

        void FixedUpdate()
        {
            if(Input.GetButton("Fire1"))
                ControlledPlane.Weapons.FirePrimary(ToMouse, lockedTarget);

            if (Input.GetButtonDown("Fire2"))
                ControlledPlane.Weapons.FireSecondary(ToMouse, lockedTarget);

            if (Input.GetKey(KeyCode.W))
                ControlledPlane.Movement.IncreaseThrust();
            else if (Input.GetKey(KeyCode.S))
                ControlledPlane.Movement.DecreaseThrust();


            if (Input.GetKey(KeyCode.A))
                ControlledPlane.Movement.StrafeLeft();
            else if (Input.GetKey(KeyCode.D))
                ControlledPlane.Movement.StrafeRight();

            var mCoord = Input.mousePosition;
            var resultSteer = screenCenter - mCoord;
            
            if (resultSteer.magnitude > DeadZone)
            {
                resultSteer.x *= -1;
                ControlledPlane.Movement.Steer(resultSteer);
            }
        }

        private Vector3 ToMouse => targetSystem.AimMouseTo(Input.mousePosition, ControlledPlane.Weapons.PrimaryStats.Range);

        void Start()
        {
            screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
            targetSystem = new TargetSystem(Camera.main, LockingLayer);
            
            BottomHud.Initialize(ControlledPlane.VehicleHealth.BaseHitPoints);
            ControlledPlane.Initialize(this, BottomHud.UpdateHp);
        }

        public void Dock(Transform hangar)
        {
            enabled = false;
            ControlledPlane.Dock(hangar);
        }

        public void Undock()
        {
            enabled = true;
            ControlledPlane.Undock();
        }

        void Update()
        {
            lockedTarget = targetSystem.ScanForTarget(ControlledPlane.Weapons.SecondaryStats.Range, LockingTime);

            if (lockedTarget != null)
                LockOnTarget.LockOn(lockedTarget);
            else
                LockOnTarget.Disengage();
        }

        public void Disable() => enabled = false;

        public void ShootDown()
        {
            Disable();
            ControlledPlane.Destroy();
        }

        public void Enable() => enabled = true;
    }
}
