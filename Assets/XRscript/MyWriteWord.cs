using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyWriteWord : MonoBehaviour
{
   private bool canWrite = true;
    private AudioSource _aduio; 


    public GameObject hintUI;

    public GameObject writtenNote;

    public GameObject letter;
    public MySubtiteController subtiteController;


    void Start()
    {
        _aduio = GetComponent<AudioSource>();
    }

    void OnTriggerStay(Collider other)
    {
        if(canWrite && other.tag.Equals("Hand")){
            if(!hintUI.activeSelf){
                hintUI.SetActive(true);
            }
            if(other.GetComponent<MyControllerInput>().sideButtonState_bool){
                transform.parent = other.gameObject.transform;
                if(_aduio != null){
                    _aduio.Play();
                }
                letter.SetActive(true);
                subtiteController.isStart = true;



                hintUI.SetActive(false); 
                writtenNote.SetActive(true);
                gameObject.SetActive(false);
                canWrite = false;
                
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
