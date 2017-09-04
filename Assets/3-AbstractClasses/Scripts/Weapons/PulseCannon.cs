using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AbstractClasses
{
    public class PulseCannon : Weapon
    {
        public override void Fire()
        {
            
        }

        public override Bullet SpawnBullet(Vector3 position, Quaternion rotation)
        {
            // Instantiate bullet at position and rotation
            GameObject clone = Instantiate(bulletPrefab, position, rotation);
            Plasma b = clone.GetComponent<Plasma>();
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