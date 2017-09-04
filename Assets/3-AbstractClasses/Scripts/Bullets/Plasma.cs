using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbstractClasses
{

    [RequireComponent(typeof(Rigidbody2D))]
    public class Plasma : Bullet
    {

        private Rigidbody2D rigid;

        void Awake()
        {
            rigid = GetComponent<Rigidbody2D>();
        }


        public override void Fire(Vector3 direction, float? speed = default(float?))
        {
            
            // Set currentSpeed to the member speed
            float currentSpeed = this.speed;
            // If the optional argument has been set
            if (speed != null) // Replace currentSpeed with the arguemnt
                currentSpeed = speed.Value;
            // Add force in the direction and currentSpeed
            rigid.AddForce(direction * currentSpeed, ForceMode2D.Impulse);
            

        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        public override void Update()
        {
            base.Update();
        }
    }
}