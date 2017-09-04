using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AbstractClasses
{


    public class WaveRay : Weapon
    {
        public int availableAmmo = 10;
        public int shootRadius = 15;
        Vector3 startPosition;

        


        public override void Fire()
        {
            for (int i = 0; i < availableAmmo; i++)
            {
                // Spawn a new bullet called 'b'
                Bullet b = SpawnBullet(transform.position, transform.rotation);
                // Calculate random angle using shoot angle

               
                // GetDir using the randomAngle
                
                // Set 'b's aliveDistance to shootRadius
                 b.lifetime = shootRadius;
                // Call b.Fire() and pass direction
              //  b.Fire(direction);
            }
        }




        public override Bullet SpawnBullet(Vector3 position, Quaternion rotation)
        {
            // Instantiate bullet at position and rotation
            GameObject clone = Instantiate(bulletPrefab, position, rotation);
            SineBullet b = clone.GetComponent<SineBullet>();
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
