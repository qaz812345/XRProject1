using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCarDoor : MonoBehaviour
{
     public GameObject hintUI;

     private AudioSource _aduio; 
     private bool canPick = true;

     public MyFadeOutController FadeOut;

     public AudioSource openDoorSFX;

    void OnTriggerStay(Collider other)
    {
        if(canPick && other.tag.Equals("Hand")){
            if(!hintUI.activeSelf){
                hintUI.SetActive(true);
            }
            if(other.GetComponent<MyControllerInput>().sideButtonState_bool){
                if(_aduio != null){
                    _aduio.Play();
                }
                hintUI.SetActive(false); 
                //gameObject.SetActive(false);
                canPick = false;
                if(FadeOut != null){
                    FadeOut.isStart = true;
                }
                if(openDoorSFX != null){
                    openDoorSFX.Play();
                }

            }
        }
    }

     void OnTriggerExit(Collider other)
    {
        if(other.tag.Equals("Hand")){
            hintUI.SetActive(false);
        }
    }
}
