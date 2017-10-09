using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Networking
{
    [RequireComponent(typeof(Player))]
    public class Networkuser : NetworkBehaviour
    {
        public Camera cam;
        public AudioListener aListener;
        private Player player;

        // Use this for initialization
        void Start()
        {
            player = GetComponent<Player>();
            if (!isLocalPlayer)
            {
                cam.enabled = false;
                aListener.enabled = false;

            }
        }

        // Update is called once per frame
        void Update()
        {
            if (isLocalPlayer)
            {
                float h = Input.GetAxis("Horizontal");
                float v = Input.GetAxis("Vertical");
                player.Move(h, v);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    player.Jump();
                }
            }
           
        }
    }
}
