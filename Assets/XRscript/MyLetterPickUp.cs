using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyLetterPickUp : MonoBehaviour
{
    private bool canPick = true;
    private bool picked = false;

    private AudioSource _aduio; 

    public GameObject hintUI;

    public GameObject letterUI;
    public GameObject backGroundUI;

    public MyControllerInput controllerInput;
    

    public MyFadeOutController fadeOutController;
    public float FadeOutDelay;
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
                controllerInput = other.GetComponent<MyControllerInput>();
                if(_aduio != null){
                    _aduio.Play();
                }
                hintUI.SetActive(false); 
                letterUI.SetActive(true);
                backGroundUI.SetActive(true);
                canPick = false;
                picked = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag.Equals("Hand")){
            hintUI.SetActive(false);
        }
    }

   
    void Update()
    {
        if(picked == true && controllerInput.GetComponent<MyControllerInput>().sideButtonState_bool){
            fadeOutController.isStart = true;
        }
    }

   
}
