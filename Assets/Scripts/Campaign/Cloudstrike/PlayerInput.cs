using Campaign.Movement;
using UnityEngine;

namespace Campaign.Cloudstrike
{
    public class PlayerInput : MonoBehaviour
    {
        public Navigator Carrier;
        public LayerMask NavigationMask;
        public Camera Camera;

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = Camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 1000f, NavigationMask))
                    Carrier.GoTo(hit.point);
            }
        }
    }
}
