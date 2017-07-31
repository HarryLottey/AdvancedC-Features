using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Delegates
{
    public class PlayerMovement : MonoBehaviour
    {
        public float acceleration = 200f;
        public float deceleration = 0.1f;

        private Rigidbody rigid;

        
        void Awake()
        {
            rigid = GetComponent<Rigidbody>();
        }

       
        void Update()
        {
            Accelerate();
            Decelerate();
        }

        void Accelerate()
        {
            // Get Input
            float inputH = Input.GetAxis("Horizontal");
            float inputV = Input.GetAxis("Vertical");
            // Calculate input direction
            Vector3 inputDir = new Vector3(inputH, 0, inputV);
            // Add force in direction by acceleration
            rigid.AddForce(inputDir * acceleration);
        }

        void Decelerate()
        {
            // Velocity = -velocity x deceleration
            rigid.velocity = -rigid.velocity * deceleration;
        }

    }
}
