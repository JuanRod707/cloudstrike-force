using System.Collections;
using Assets.Scripts.Battle.Weapons.Data;
using UnityEngine;

namespace Assets.Scripts.Battle.Weapons
{
    public class Weapon : MonoBehaviour
    {
        public WeaponStats Stats;
        public AudioSource FireSfx;
        
        bool isCycling;
        int currentAmmo;
        
        public void Fire(Vector3 position, Transform target)
        {
            if (!isCycling)
            {
                FireRound(position, target);
                PostFire();
            }
        }

        void PostFire()
        {
            if (gameObject.activeInHierarchy)
            {
                FireSfx.Play();
                StartCoroutine(Cycle());
                currentAmmo--;
                if (currentAmmo <= 0)
                    Reload();
            }
        }

        public void Reload()
        {
            StartCoroutine(WaitForReload());
        }
        
        protected virtual void FireRound(Vector3 position, Transform target) { }

        IEnumerator Cycle()
        {
            isCycling = true;
            yield return new WaitForSeconds(Stats.RateOfFire);
            isCycling = false;
        }

        IEnumerator WaitForReload()
        {
            isCycling = true;
            currentAmmo = 0;
            yield return new WaitForSeconds(Stats.ReloadTime);
            currentAmmo = Stats.Ammo;
            isCycling = false;
        }
    }
}
