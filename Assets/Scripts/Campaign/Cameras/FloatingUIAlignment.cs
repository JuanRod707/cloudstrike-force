using UnityEngine;

namespace Campaign.Cameras
{
    public class FloatingUIAlignment : MonoBehaviour
    {
        private Camera cam;

        void Start() => cam = Camera.main;

        void Update()
        {
            transform.rotation = cam.transform.rotation;
        }
    }
}
