using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPickUpBeer : MonoBehaviour
{
    private bool canPick = true;

    public GameObject hintUI;
    private AudioSource _aduio; 

    public MyAIIKcontroller aIIKcontroller;
    // Start is called before the first frame update
    void Start()
    {
        _aduio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
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
                aIIKcontroller.HasPickUp();
                gameObject.SetActive(false);
                canPick = false;
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
