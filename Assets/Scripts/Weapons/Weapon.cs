using System.Collections;
using UnityEngine;
using Weapons.Data;

namespace Weapons
{
    public class Weapon : MonoBehaviour
    {
        public WeaponStats Stats;
        public AudioSource FireSfx;
        
        bool isCycling;
        int currentAmmo;

        public void Fire()
        {
            if (!isCycling)
            {
                FireRound();
                FireSfx.Play();
                StartCoroutine(Cycle());
                currentAmmo--;
                if(currentAmmo <= 0)
                    Reload();
            }
        }

        public void Reload()
        {
            StartCoroutine(WaitForReload());
        }

        protected virtual void FireRound() { }

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
