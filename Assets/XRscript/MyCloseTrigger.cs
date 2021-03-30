using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCloseTrigger : MonoBehaviour
{
    private bool isClose = false;

    public float waitPlaySound;
    public MyDoorController DoorController;

    public MyCharacterController characterController;

    public AudioSource closeDoorSFX;

    void OnTriggerEnter(Collider other)
    {

        if(other.tag.Equals("NPC") && !isClose){
            isClose = true;
            DoorController.isOpen = false;
            characterController.CanMove = true;
            StartCoroutine(PlaySound());       
         }
    }

    IEnumerator PlaySound(){
        yield return new WaitForSeconds(waitPlaySound);
        closeDoorSFX.Play();
    }
}
