using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbstractClasses
{

    [RequireComponent(typeof(Rigidbody2D))]
    public class SineBullet : Bullet
    {
        Vector3 startPosition;

        public bool useSin = false;
        public bool useCos = false;
        [Header("Sine")]
        public float sin_Amplitude;
        public float sin_Frequency;
        public float sin_PhaseShift;
        [Header("Cosine")]
        public float cos_Amplitude;
        public float cos_Frequency;
        public float cos_PhaseShift;


        private Rigidbody2D rigid;

        float x;
        float y;
        float z;

        Vector3 sinDir;

        void Awake()
        {
            rigid = GetComponent<Rigidbody2D>();
        }

        public override void Fire(Vector3 direction, float? speed = default(float?))
        {
            

           
        }

       
        void Start()
        {
            x = startPosition.x;
            y = startPosition.y;
            z = startPosition.z;
            sinDir = new Vector3();
        }

       
        public override void Update()
        {
            base.Update();

            startPosition = transform.position;

            if (useSin)
                x = x + sin_Amplitude * Mathf.Sin(Time.timeSinceLevelLoad) * sin_Frequency + sin_PhaseShift; // Moves on the z axis modified by the variables

            if (useCos)
                x = x + cos_Amplitude * Mathf.Cos(Time.timeSinceLevelLoad) * cos_Frequency + cos_PhaseShift;



             transform.position = new Vector3(x, y, z);

        }

       

           
        
            

        }

}

