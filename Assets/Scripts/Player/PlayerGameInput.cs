using UnityEngine;
using Vehicles;

namespace Player
{
    public class PlayerGameInput : MonoBehaviour
    {
        public Vehicle Ship;
        public float DeadZone;

        private Vector3 screenCenter;

        void FixedUpdate()
        {
            if(Input.GetButton("Fire1"))
                Ship.Weapons.FirePrimary();

            if (Input.GetButton("Fire2"))
                Ship.Weapons.FireSecondary();

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

        void Start() => screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);

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
    }
}
