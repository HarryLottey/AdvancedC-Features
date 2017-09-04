using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AbstractClasses
{

    [RequireComponent(typeof(Rigidbody2D))]
    public class HomingBullet : Bullet
    {

        public Transform target;
        public float seekRange;
        Vector2 seekPos;

        public override void Fire(Vector3 direction, float? speed = default(float?))
        {
            // Set currentSpeed to the member speed
            float currentSpeed = this.speed;
            // If the optional argument has been set
            if (speed != null) // Replace currentSpeed with the arguemnt
                currentSpeed = speed.Value;
            // Add force in the direction and currentSpeed
            Rigidbody2D rigi = GetComponent<Rigidbody2D>();
            rigi.AddForce(direction * currentSpeed, ForceMode2D.Impulse);

        }


        void Start()
        {
            seekPos = new Vector2(transform.position.x, transform.position.y);
        }

        
        public override void Update()
        {
            base.Update(); // Destroy the bullet after a bit

            if(Physics2D.OverlapCircle(seekPos, seekRange)) // Range in which the bullet has to be to the target before it starts to seek.
            {
                print("???");
            }
            if(target != null)
            transform.LookAt(target); // Look at the target once it has been assigned.

        }
    }
}
