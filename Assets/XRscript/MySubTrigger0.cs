using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySubTrigger0 : MonoBehaviour
{
    public bool canTrigger;
    public MySubtiteController subtiteController;

    void OnTriggerStay(Collider other)
    {
        if(canTrigger && other.tag.Equals("Hand")){
            canTrigger = false;
            subtiteController.isStart = true;
          
    }
    }
}
