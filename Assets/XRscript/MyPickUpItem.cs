using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPickUpItem : MonoBehaviour
{
    private bool canPick = true;
    private AudioSource _aduio; 

    public GameObject hintUI;

    public MyFadeOutController FadeOut;

    public MyDoorController DoorController;

    public AudioSource source;

    void Start()
    {
        _aduio = GetComponent<AudioSource>();
    }

    void OnTriggerStay(Collider other)
    {
        if(canPick && other.tag.Equals("Hand")){
            if(!hintUI.activeSelf){
                hintUI.SetActive(true);
            }
            if(other.GetComponent<MyControllerInput>().sideButtonState_bool){
                transform.parent = other.gameObject.transform;
                if(_aduio != null){
                    _aduio.Play();
                }
                hintUI.SetActive(false); 
                gameObject.SetActive(false);
                canPick = false;
                if(FadeOut != null){
                    FadeOut.isStart = true;
                }
                if(DoorController != null){
                    DoorController.isOpen = true;
                }
                if(source != null){
                    source.Play();
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
