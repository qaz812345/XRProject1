using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyArgumentScene : MonoBehaviour
{

    public MyFadeOutController fadeOutController;
    public MySubtiteController mySubtiteController;
    // Start is called before the first frame update
    void Start()
    {
        mySubtiteController.EndTalkHandler += ()=>{fadeOutController.isStart=true;};
    }
}
