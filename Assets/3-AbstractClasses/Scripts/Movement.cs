using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AbstractClasses
{
    public class Movement : MonoBehaviour
    {
        public float acceleration = 50f;
        public float hyperSpeed = 100f;
        [Range(0, 1)]
        [Tooltip("Deceleration as a percentage of the current velocity")]
        public float deceleration = 0.1f;
        public float rotationSpeed = 20f;

        private Rigidbody2D rigid;
        
        void Awake()
        {
            rigid = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            Accelerate();
            Decelerate();
            Rotate();
        }

        void Accelerate()
        {
            float inputV = Input.GetAxis("Vertical");
            Vector3 force = transform.right * inputV;
            
            // Check if left shift i spressed
            if (Input.GetKey(KeyCode.LeftShift))
            {
                // Go hyperspeed
                force *= hyperSpeed;
            }
            else
            {
                // Dont go hyperspeed
                force *= acceleration;
            }

            rigid.AddForce(force);

        }

        void Decelerate()
        {
            rigid.velocity += -rigid.velocity * deceleration;
        }

        void Rotate()
        {
            float inputH = Input.GetAxis("Horizontal");
            transform.rotation *= Quaternion.AngleAxis(rotationSpeed * inputH, Vector3.back);

        }
    }
}