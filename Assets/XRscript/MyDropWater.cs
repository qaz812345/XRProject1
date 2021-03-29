using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDropWater : MonoBehaviour
{
    private bool IsDrop = false;
    public MyCharacterAddForce characterAddForce;

    public MyFadeOutController fadeOutController;

    public float FadeOutDelayTime = 2.0f;

    void OnTriggerStay(Collider other)
    {
        if(!IsDrop && other.tag.Equals("Character")){
           IsDrop = true;
           characterAddForce.AdjustDrag();
           StartCoroutine(startFade());
        }
    }

    IEnumerator startFade(){
        yield return new WaitForSeconds(FadeOutDelayTime);
        fadeOutController.isStart = true;
    }

}
