using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace starfoxclone
{

    public class ArwingController : MonoBehaviour
    {

        public enum Mode
        {
            CONFINED = 0,
            ALL_RANGE = 1
        }

        public Mode arwingMode = Mode.CONFINED;

        [Header("Camera")]
        public float cameraYSpeed = 0.5f;
        public float cameraMoveSpeed = 20f;
        public float cameraDistance = 5f;

        [Header("Arwing")]
        public Transform moveTarget;
        public Transform aimTarget;
        public float movementSpeed = 20f;
        public float aimingSpeed = 20f;
        public float rotationSpeed = 20f;

        public float h;
        public float v;

        private Camera parentCam;
        private float startDistance = 5f;
        private Vector3 up = Vector3.up;


        // Use this for initialization
        void Start()
        {
            parentCam = GetComponentInParent<Camera>();
            // Set startdistance to distance betweemn parent cam and arwing
            startDistance = Vector3.Distance(parentCam.transform.position, transform.position);
        }

        // Update is called once per frame
        void Update()
        {

        }

    

        // Moves the arwing to the target gameobject
        void MoveTargetToArwing()
        {
            // get the aim targets local position
            Vector3 localAimTargetPos = aimTarget.transform.localPosition;
            Vector3 localArwingPos = transform.localPosition;
            // Move aim target towards local arwing
            localAimTargetPos = Vector3.MoveTowards(localAimTargetPos, localArwingPos, movementSpeed * Time.deltaTime);

            // apply the position

            aimTarget.transform.localPosition = localAimTargetPos;
            transform.localPosition = localArwingPos;

        }

        // Moves the target gameobject to arwing
        void MoveArwingToMoveTarget()
        {
            // get the globa aim targets local position
            Vector3 moveTargetPos = moveTarget.position;
            Vector3 arwingPos = transform.position;
            // Move arwing to the aim target
            arwingPos = Vector3.MoveTowards(arwingPos, moveTargetPos, movementSpeed * Time.deltaTime);



            // apply the position

            
            transform.position = arwingPos;

            // reset z locally
            Vector3 localArwingPos = transform.localPosition;
            localArwingPos.z = startDistance;
            transform.localPosition = localArwingPos;
        }

        // Rotates the arwing to the aimtarget gameobject
        void RotateToAimTarget()
        {
            // Get direction to aim target
            Vector3 direction = aimTarget.position - transform.position;

            // Get rotation to up
            Quaternion rotation = Quaternion.LookRotation(direction.normalized, up);
            // Lerp rotation for arwing
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, aimingSpeed * Time.deltaTime);

        }

        // Moves forward with camera
        void MoveForward()
        {
            parentCam.transform.position += parentCam.transform.forward * cameraMoveSpeed * Time.deltaTime;
        }

        // Get camera to follow arwing only in allrange mode
        void FollowArwing()
        {
            // Get Camera's position & rotation
            Vector3 position = parentCam.transform.position;
            Quaternion rotation = parentCam.transform.rotation;

            // Get local position of target and arwing
            Vector3 localArwingPos = transform.localPosition;
            Vector3 localTargetPos = moveTarget.localPosition;

            // Calculate direction with LocalPos
            Vector3 direction = localTargetPos - localArwingPos;

            // Rotate the camera to direction
            rotation *= Quaternion.AngleAxis(direction.x * rotationSpeed * Time.deltaTime, Vector3.up);

            // Move the camera up at different speed
            position.y += direction.y * cameraYSpeed * Time.deltaTime;

            // Apply newly made position to camera
            parentCam.transform.position = position;
            parentCam.transform.rotation = rotation;


        }


        void MoveTarget(float inputH, float inputV)
        {
            // Getinput dir
            Vector3 inputDir = new Vector3(inputH, inputV, 0);
            // calculate force by inputDir x movementSpeed
            Vector3 force = inputDir * movementSpeed;
            // offset aimtarget by force
            moveTarget.localPosition += force * Time.deltaTime;
        }

        public void Move(float inputH, float inputV)
        {
            // Move the target

            MoveTarget(inputH, inputV);

            // Move Foward
            MoveForward();
            // Move based on arwing mode

            switch (arwingMode)
            {
                case Mode.CONFINED:
                    break;
                case Mode.ALL_RANGE:
                    FollowArwing();
                    break;
                default:
                    break;
            }

            // If no input was made
            if (inputH == 0 & inputV == 0)
            {
                // Move target to arwing
                MoveTargetToArwing();
            }
            
            // Move the arwing to the movetarget
            MoveArwingToMoveTarget();

            // rotate arwing to aim target
            RotateToAimTarget(); // not implemented yet


        }
        

    }
}
