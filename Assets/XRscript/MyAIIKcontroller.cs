using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAIIKcontroller : MonoBehaviour
{
     protected Animator animator;
    
    public bool ikActive = false;

    public bool hasPicked = false;

    public Transform rightHandObj = null;
    public Transform leftHandObj = null;
    public Transform lookObj = null;

    public float waitTimeLength = 5.0f;

    public float startIkTime = 1.5f;

    public float startTalkTime = 3.0f;

    public GameObject beerOnTable;
    public GameObject beerOnHand;

     public GameObject beerOnSide;

    public MyGiveBeerrSub giveBeerrSub;
    public MyCarSub subtiteController;

    public MyFadeOutController fadeOutController;
    
    public float ikWeight;

    private bool IsStartTalk = false;

    public bool IsLookAt = false;

    private float currentWeight = 0.0f;

    public float LerpSpeed = 3f;

     public float LerpOutSpeed = 3f;

    
 

    void Start () 
    {
        animator = GetComponent<Animator>();
        IsStartTalk = false;
        subtiteController.EndTalkHandler += FadeOut;
    }

    public void PickUpBeer(){
        beerOnTable.SetActive(false);
        beerOnHand.SetActive(true);
    }

    public void HoldOnBeer(){
        animator.SetFloat("animationSpeed",0);
        StartCoroutine(PickUpTimer());
        
    }

    public void FadeOut(){
        fadeOutController.isStart = true;
    }

    public void GiveBeer(){
        ikActive = false;
        animator.SetTrigger("OnGiveButton");
    }

    public void ShowGiveSub(){
        giveBeerrSub.SetSub(true);
    }

    public void HasPickUp(){
        hasPicked = true;
        animator.SetTrigger("OnDriving");
        animator.SetFloat("animationSpeed",1);
        giveBeerrSub.SetSub(false);
         StartCoroutine(StartTalk(1.5f));
    }

    public void PutDownBeer(){
        if(hasPicked == false){
            beerOnHand.SetActive(false);
            beerOnSide.SetActive(true);
        }
    }

    IEnumerator PickUpTimer(){
        yield return new WaitForSeconds(waitTimeLength);
        if(hasPicked == false){
            animator.SetFloat("animationSpeed",1);
            giveBeerrSub.SetSub(false);
            StartCoroutine(StartTalk(5.5f));
        }
    }

     IEnumerator StartTalk(float ikTIme){
        if(IsStartTalk == false){
            IsStartTalk = true;
            yield return new WaitForSeconds(ikTIme);
            ikActive = true;
            yield return new WaitForSeconds(startTalkTime);
            subtiteController.isStart = true;
        }
    }


     void OnAnimatorIK()
    {
        if(animator) {
            
            //if the IK is active, set the position and rotation directly to the goal. 
            if(ikActive) {

                // Set the look target position, if one has been assigned
              

                // Set the right hand target position and rotation, if one has been assigned
                if(rightHandObj != null) {
                    animator.SetIKPositionWeight(AvatarIKGoal.RightHand,ikWeight);
                    animator.SetIKRotationWeight(AvatarIKGoal.RightHand,ikWeight);  
                    animator.SetIKPosition(AvatarIKGoal.RightHand,rightHandObj.position);
                    animator.SetIKRotation(AvatarIKGoal.RightHand,rightHandObj.rotation);
                }  

                if(leftHandObj != null) {
                    animator.SetIKPositionWeight(AvatarIKGoal.LeftHand,ikWeight);
                    animator.SetIKRotationWeight(AvatarIKGoal.LeftHand,ikWeight);  
                    animator.SetIKPosition(AvatarIKGoal.LeftHand,leftHandObj.position);
                    animator.SetIKRotation(AvatarIKGoal.LeftHand,leftHandObj.rotation);
                }             
                
            }
            
            //if the IK is not active, set the position and rotation of the hand and head back to the original position
            else {          
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand,0);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand,0); 
                animator.SetIKPositionWeight(AvatarIKGoal.LeftHand,0);
                animator.SetIKRotationWeight(AvatarIKGoal.LeftHand,0); 
            }
        }

        if(IsLookAt){
             if(currentWeight < 0.75f){
                 currentWeight += Time.deltaTime* LerpSpeed;
             }else{
                 currentWeight = 0.75f;
             }
        }else{
              if(currentWeight >= 0.0f){
                 currentWeight -= Time.deltaTime* LerpOutSpeed;
             }else{
                 currentWeight = 0.0f;
             }
        }
        if(lookObj != null){
        animator.SetLookAtWeight(currentWeight);
        animator.SetLookAtPosition(lookObj.transform.position);
        }
    }


}
