using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Weapons
{
    using UnityEngine;

    public abstract class WeaponClass
    {
        public float range;
        public float damage;
        public float shootingSpeed;
        public AmmoType ammoType;
        public bool singleShot;

        public abstract void Shoot();


  
        public virtual void Reload()
        {


            Debug.Log("Reloading...");
        }
    }

    public class HeavyWeapon : WeaponClass
    {
        public HeavyWeapon()
        {
            range = 50f;
            damage = 50f;
            shootingSpeed = 0.5f;
            ammoType = AmmoType.Heavy;
            singleShot = true;
        }

        public override void Shoot()
        {
            // Implementation of Shoot for HeavyWeapon
            Debug.Log("Firing heavy weapon!");
        }
    }

    public class PistolWeapon : WeaponClass
    {
        public PistolWeapon()
        {
            range = 25f;
            damage = 10f;
            shootingSpeed = 0.2f;
            ammoType = AmmoType.Pistol;
            singleShot = true;
        }

        public override void Shoot()
        {
            // Implementation of Shoot for PistolWeapon
            Debug.Log("Firing pistol!");
        }
    }

    public class RifleWeapon : WeaponClass
    {
        public RifleWeapon()
        {
            range = 100f;
            damage = 30f;
            shootingSpeed = 0.3f;
            ammoType = AmmoType.Rifle;
            singleShot = false;
        }

        public override void Shoot()
        {
            // Implementation of Shoot for RifleWeapon
            Debug.Log("Firing rifle!");
        }
    }

    public class SniperWeapon : WeaponClass
    {
        public SniperWeapon()
        {
            range = 500f;
            damage = 100f;
            shootingSpeed = 0.1f;
            ammoType = AmmoType.Sniper;
            singleShot = true;
        }

        public override void Shoot()
        {
            // Implementation of Shoot for SniperWeapon
            Debug.Log("Firing sniper rifle!");
        }
    }

    public enum AmmoType
    {
        Heavy,
        Pistol,
        Rifle,
        Sniper
    }


}

