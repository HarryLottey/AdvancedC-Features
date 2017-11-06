using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace starfoxclone
{


    public class UserController : MonoBehaviour
    {
        public ArwingController arwingController;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            // get input H & V
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            arwingController.Move(h, v);
            // move controller based on these inputs

            // EXTRAS
            // Call arwing shoot if we press a button

            // 
        }
    }
}
