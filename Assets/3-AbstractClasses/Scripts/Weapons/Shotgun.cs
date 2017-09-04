using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// Preprocessor Directives
#if UNITY_EDITOR
using UnityEditor;
#endif


namespace AbstractClasses
{
    public class Shotgun : Weapon
    {
        public float shootAngle = 45f;
        public float shootRadius = 5f;
        public int shells = 10;

        private Vector2 leftDir, rightDir;

        public Vector2 GetDir(float angleD)
        {
            float angleR = angleD * Mathf.Deg2Rad;
            Vector2 dir = new Vector2(Mathf.Cos(angleR), Mathf.Sin(angleR));
            return transform.rotation * dir;
        }
        



        public override void Fire()
        {


            // Loop through and spawn bullets
            for (int i = 0; i < shells; i++)
            {
                // Spawn a new bullet called 'b'
                Bullet b = SpawnBullet(transform.position, transform.rotation);
                // Calculate random angle using shoot angle

                float randomAngle = Random.Range(-shootAngle, +shootAngle);
                // GetDir using the randomAngle
                Vector3 direction = GetDir(randomAngle);
                // Set 'b's aliveDistance to shootRadius
                b.lifetime = shootRadius;
                // Call b.Fire() and pass direction
                b.Fire(direction);
            }
                
                
        }


        public override Bullet SpawnBullet(Vector3 position, Quaternion rotation)
        {
            
            // Instantiate bullet at position and rotation
            GameObject clone = Instantiate(bulletPrefab, position, rotation);
            Bullet b = clone.GetComponent<Plasma>();
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

#if UNITY_EDITOR
    [CanEditMultipleObjects]
    [CustomEditor(typeof(Shotgun))]
    public class ShotgunEditor : Editor
    {
        void OnSceneGUI()
        {
            Shotgun shotgun = (Shotgun)target;
            Transform transform = shotgun.transform;
            Vector2 pos = transform.position;
            float angle = shotgun.shootAngle;
            float radius = shotgun.shootRadius;
            Vector2 leftDir = shotgun.GetDir(angle);
            Vector2 rightDir = shotgun.GetDir(-angle);
            Handles.color = Color.green;
            Handles.DrawLine(pos, pos + leftDir * shotgun.shootRadius);
            Handles.DrawLine(pos, pos + rightDir * shotgun.shootRadius);
            Handles.color = Color.grey;
            Handles.DrawWireArc(pos, Vector3.forward, rightDir, angle * 2, radius);

        }
    }
#endif

}
