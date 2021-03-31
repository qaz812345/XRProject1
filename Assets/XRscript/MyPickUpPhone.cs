using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPickUpPhone : MonoBehaviour
{
    

    public GameObject hintUI;

    public MySubtiteController subtiteController;

    public float firstWaitingTime;

    public float firstRingTime;

    public float secondWaitingTime;

    public float secondRingTime;
    
    public Vector3 adustedPosition;
    public Vector3 adustedRotation;
    public Vector3 adustedScale;
    
    private MyLightController _lightController;
    private MyRingController _ringController;
    private bool canPick = false;

    public AudioSource pickUpSFX;



    void Start()
    {
        canPick = false;
        _lightController = GetComponentInChildren<MyLightController>();
        _ringController = GetComponentInChildren<MyRingController>();
        StartCoroutine(RingEvent());
        subtiteController.EndTalkHandler += DisablePhone;
    }

    IEnumerator RingEvent(){
        yield return new WaitForSeconds(firstWaitingTime);
        _lightController.IsActive = true;
        _ringController.SetAudioActive(true);
        canPick = true;
        yield return new WaitForSeconds(firstRingTime);
        if(canPick == true){
            _lightController.IsActive = false;
            _ringController.SetAudioActive(false);
            canPick = false;
            hintUI.SetActive(false); 
            yield return new WaitForSeconds(secondWaitingTime);
            _lightController.IsActive = true;
            _ringController.SetAudioActive(true);
            canPick = true;
            yield return new WaitForSeconds(secondRingTime);
             if(canPick == true){
                _lightController.IsActive = false;
                _ringController.SetAudioActive(false);
                hintUI.SetActive(false); 
                canPick = false;       
             }
        }
    }

    public void DisablePhone(){
        _lightController.IsActive = false;
        _ringController.SetAudioActive(false);
        hintUI.SetActive(false); 
        transform.gameObject.SetActive(false);
    }

    

 
    void OnTriggerStay(Collider other)
    {
        if( canPick && other.tag.Equals("Hand")){
            if(!hintUI.activeSelf){
                hintUI.SetActive(true);
            }
            if(other.GetComponent<MyControllerInput>().sideButtonState_bool){
                pickUpSFX.Play();
                transform.parent = other.gameObject.transform;
                transform.localScale = adustedScale;
                transform.localRotation = Quaternion.Euler(adustedRotation);
                transform.localPosition = adustedPosition;
                hintUI.SetActive(false); 
                _lightController.IsActive = false;
                _ringController.SetAudioActive(false);
                subtiteController.isStart = true;
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
