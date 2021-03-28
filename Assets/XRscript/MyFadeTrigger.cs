using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFadeTrigger : MonoBehaviour
{
    public bool canTrigger;
    public MyFadeOutController fadeOutController;

    void OnTriggerStay(Collider other)
    {
        if(canTrigger && other.tag.Equals("Hand")){
            canTrigger = false;
            fadeOutController.isStart = true;
          
    }
    }
}
