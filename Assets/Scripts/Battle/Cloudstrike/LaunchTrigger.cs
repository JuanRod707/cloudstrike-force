using UnityEngine;

namespace Assets.Scripts.Battle.Cloudstrike
{
    public class LaunchTrigger : MonoBehaviour
    {
        public PlayerGameInput PlayerInput;
        public Transform Hangar;

        void Start() => PlayerInput.Dock(Hangar);

        void Update()
        {
            if(Input.anyKeyDown)
                Undock();
        }

        void Undock()
        {
            enabled = false;
            PlayerInput.Undock();
        }
    }
}
