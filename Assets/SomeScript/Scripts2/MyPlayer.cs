using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KinematicCharacterController;
using KinematicCharacterController.Examples;
using System.Linq;

namespace KinematicCharacterController.Walkthrough.BasicMovement
{
    public class MyPlayer : MonoBehaviour
    {
        private Camera _camera;
       // public ExampleCharacterCamera OrbitCamera;
        public MyCharacterController character;

        public MyControllerInput rightHand;
        public MyControllerInput leftHand;


        // private const string MouseXInput = "Mouse X";
        // private const string MouseYInput = "Mouse Y";
        // private const string MouseScrollInput = "Mouse ScrollWheel";
        // private const string HorizontalInput = "Horizontal";
        // private const string VerticalInput = "Vertical";

        private void Start()
        {
            

            // Tell camera to follow transform
            _camera = Camera.main;

            // Ignore the character's collider(s) for camera obstruction checks
           // OrbitCamera.IgnoredColliders.Clear();
           // OrbitCamera.IgnoredColliders.AddRange(Character.GetComponentsInChildren<Collider>());
        }

    
        void Update()
        {
            
            Debug.Log(0);
           // HandleCharacterInput();
        }

        private void HandleCameraInput()
        {
            // Create the look input vector for the camera
            // float mouseLookAxisUp = Input.GetAxisRaw(MouseYInput);
            // float mouseLookAxisRight = Input.GetAxisRaw(MouseXInput);
            // Vector3 lookInputVector = new Vector3(mouseLookAxisRight, mouseLookAxisUp, 0f);

            // // Prevent moving the camera while the cursor isn't locked
            // if (Cursor.lockState != CursorLockMode.Locked)
            // {
            //     lookInputVector = Vector3.zero;
            // }

            // // Input for zooming the camera (disabled in WebGL because it can cause problems)
            // float scrollInput = -Input.GetAxis(MouseScrollInput);


            // Apply inputs to the camera
            //OrbitCamera.UpdateWithInput(Time.deltaTime, scrollInput, lookInputVector);

            // Handle toggling zoom level
            // if (Input.GetMouseButtonDown(1))
            // {
            //     OrbitCamera.TargetDistance = (OrbitCamera.TargetDistance == 0f) ? OrbitCamera.DefaultDistance : 0f;
            // }
        }

        private void HandleCharacterInput()
        {
            PlayerCharacterInputs characterInputs = new PlayerCharacterInputs();

            // Build the CharacterInputs struct
            characterInputs.MoveAxisForward = leftHand.touchpadState_vector2.y;
            characterInputs.MoveAxisRight = leftHand.touchpadState_vector2.x;
            
            characterInputs.CameraRotation = _camera.transform.rotation;

            // Apply inputs to character
            character.SetInputs(ref characterInputs);
        }
    }
}