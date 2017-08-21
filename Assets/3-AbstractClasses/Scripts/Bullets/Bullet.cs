using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbstractClasses
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Bullet : MonoBehaviour
    {
        public float speed = 10f;
        public float lifetime = 5f;


        private Rigidbody2D rigid;
        private Vector3 firePos;

        void Awake()
        {
            rigid = GetComponent<Rigidbody2D>();
        }

        void Start()
        {
            firePos = transform.position;
        }

        void Update()
        {
            float distance = Vector3.Distance(firePos, transform.position);

            if (distance > lifetime)
                Destroy(gameObject);
        }

        public abstract void Fire(Vector3 direction, float? speed = null);
        
            /*
            {
            // Set currentSpeed to the member speed
            float currentSpeed = this.speed;
            // If the optional argument has been set
            if (speed != null) // Replace currentSpeed with the arguemnt
                currentSpeed = speed.Value;
            // Add force in the direction and currentSpeed
            rigid.AddForce(direction * currentSpeed, ForceMode2D.Impulse);
            }
            */
        


    }
}
