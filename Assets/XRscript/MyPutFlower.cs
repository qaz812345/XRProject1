using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPutFlower : MonoBehaviour
{
    private bool canPick = true;
    private AudioSource _aduio; 

    public GameObject hintUI;

    public GameObject flowOnGround;
    public GameObject flowOnHand;

    public MyFadeEnd fadeEnd;
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
                if(_aduio != null){
                    _aduio.Play();
                }
                hintUI.SetActive(false); 
                flowOnHand.SetActive(false);
                flowOnGround.SetActive(true);
                canPick = false;
                fadeEnd.isStart = true;
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
