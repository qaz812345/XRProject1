using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class MyControllerInput : MonoBehaviour
{
     public SteamVR_Input_Sources handType;

    public SteamVR_Action_Vector2 touchpad_vector2;
    public SteamVR_Action_Single triggerButton_vector1;


    public bool sideButtonState_bool;
  

    public Vector2 touchpadState_vector2;



    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
        sideButtonState_bool = triggerButton_vector1.GetAxis(handType) > 0.3f;
     

        touchpadState_vector2 = touchpad_vector2.GetAxis(handType);

      
    }
}
