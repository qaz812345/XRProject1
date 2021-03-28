using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCloseTrigger : MonoBehaviour
{
    public MyDoorController DoorController;

    public MyCharacterController characterController;

    void OnTriggerEnter(Collider other)
    {

        if(other.tag.Equals("NPC")){
            DoorController.isOpen = false;
            characterController.CanMove = true;
        }
    }
}
