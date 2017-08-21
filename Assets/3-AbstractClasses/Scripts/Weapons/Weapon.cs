using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbstractClasses
{

    public abstract class Weapon : MonoBehaviour
    {
        
        public float fireInterval = 0.2f;
        public float recoil = 5f;
        public int damage = 10;
        public int ammo = 0;
        public int maxAmmo = 30;
        
        public GameObject bulletPrefab;
        public GameObject muzzleFlash;







        public abstract void Fire();
        public virtual void Reload()
        {
            ammo = maxAmmo;
        }

        public Bullet SpawnBullet(Vector3 position, Quaternion rotation)
        {
            // Instantiate bullet at position and rotation
            GameObject clone = Instantiate(bulletPrefab, position, rotation);
            Bullet b = clone.GetComponent<Bullet>();
            // Play Sound
            

            // Instantiate muzzle flash
            //Instantiate(muzzleFlash, position, rotation);
            // Set bullet's direction

            // Reduce the current ammo by 1
            ammo--;
            // Return bullet
            return b;
        }


        
    }
}
