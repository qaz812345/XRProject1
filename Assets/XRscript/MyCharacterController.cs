using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharacterController : MonoBehaviour
{
    public MyControllerInput rightHand;
    public MyControllerInput leftHand;

    public float movementSpeed;

    private Vector3 _moveDir;

    public Vector3 initPos;
    
    private Camera _camera;

    public bool CanMove = false;

    public MySubtiteController subtitle;

    


    // Start is called before the first frame update
    void Start()
    {
        transform.position = initPos;
        _camera = Camera.main;
        if(subtitle != null){
            subtitle.EndTalkHandler += StartCanMove;
        }
    }

    void StartCanMove(){
        CanMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(leftHand.touchpadState_vector2.magnitude > 0.3 && CanMove ){
            _moveDir.x = leftHand.touchpadState_vector2.x;
            _moveDir.z = leftHand.touchpadState_vector2.y;
            _moveDir = _moveDir.normalized;

            Vector3 cameraPlanarDirection = Vector3.ProjectOnPlane( _camera.transform.rotation * Vector3.forward, Vector3.up).normalized;
            Quaternion cameraPlanarRotation = Quaternion.LookRotation(cameraPlanarDirection, Vector3.up);

            transform.position +=  cameraPlanarRotation * _moveDir * Time.deltaTime * movementSpeed;
        }
    }
}
