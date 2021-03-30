using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MyAIMovement : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _anim;

    public Transform target;
    public bool StartMove;


    public Transform lookObj;
    private bool ikActive = true;
    

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //_anim.SetFloat("speed", _agent.velocity.magnitude);
        if(StartMove){
            ikActive = false;
            _agent.SetDestination (target.transform.position);
        }
    }

    public void StartWalk(){
        _anim.applyRootMotion = false;
        StartMove = true;
    }

     void OnAnimatorIK()
    {   
        if(lookObj != null) {
                    _anim.SetLookAtWeight(0.75f);
                    _anim.SetLookAtPosition(lookObj.position);
        }else{
                    _anim.SetLookAtWeight(0.0f);
                    _anim.SetLookAtPosition(lookObj.position);
        } 
    }
}
