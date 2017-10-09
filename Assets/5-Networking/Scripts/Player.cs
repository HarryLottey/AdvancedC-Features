using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Networking
{



    public class Player : MonoBehaviour
    {

        public float movementSpeed = 10f;
        public float rotationSpeed = 10f;
        public float jumpHeight = 2.0f;

        private Rigidbody rigid;
        bool isGrounded;

        // Use this for initialization
        void Start()
        {
            rigid = GetComponent<Rigidbody>();
        }

        public void Move(float h, float v)
        {
            Vector3 position = rigid.position;
            Quaternion rotation = rigid.rotation;
                     
            position += transform.forward * v * movementSpeed * Time.deltaTime;
            rotation *= Quaternion.AngleAxis(rotationSpeed * h, Vector3.up);
           
            rigid.MovePosition(position);
            rigid.MoveRotation(rotation);  
        }

       public void Jump()
        {
            if (isGrounded)
            {
                rigid.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
                isGrounded = false;
            }
        }
        
        void OnCollisionEnter(Collision col)
        {
            isGrounded = true;
        }

    }
}
