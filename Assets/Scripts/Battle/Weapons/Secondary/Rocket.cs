using UnityEngine;

namespace Battle.Weapons.Secondary
{
    public class Rocket : MonoBehaviour
    {
        public float Speed;
        public float Lifetime;
        public float SafeTime;

        public Warhead Warhead;
        public GameObject Explosion;
        public GameObject View;
        public float ClearTime;

        public void Launch(int damage) => Warhead.Initialize(this, damage, SafeTime);
        
        public void Destroy()
        {
            Instantiate(Explosion, transform.position, Quaternion.identity);
            View.SetActive(false);
            Destroy(gameObject, ClearTime);
            enabled = false;
        }

        protected virtual void FixedUpdate()
        {
            transform.Translate(Vector3.forward * Speed);
            SpendFuel();
        }

        protected void SpendFuel()
        {
            Lifetime -= Time.fixedDeltaTime;
            if(Lifetime <= 0)
                Destroy();
        }
    }
}
