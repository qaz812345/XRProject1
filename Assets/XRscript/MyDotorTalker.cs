using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDotorTalker : MonoBehaviour
{
    public MySubtiteController mySubtiteControllerWake;
    public MySubtiteController mySubtiteControllerTalk;
    public MyFadeOutController myFadeOutController;

    public Transform lookObj = null;


    private Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        mySubtiteControllerWake.EndTalkHandler += ()=>{
            mySubtiteControllerTalk.isStart = true;
            _anim.SetTrigger("OnStand");
        };
        mySubtiteControllerTalk.EndTalkHandler += ()=>{ myFadeOutController.isStart = true;};
    }

    // Update is called once per frame
    void Update()
    {
        
    }
      void OnAnimatorIK()
    {
      _anim.SetLookAtWeight(0.75f);
      _anim.SetLookAtPosition(lookObj.position);
    }
}
