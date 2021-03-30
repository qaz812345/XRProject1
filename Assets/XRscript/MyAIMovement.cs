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
            _agent.SetDestination (target.transform.position);
        }
    }

    public void StartWalk(){
        _anim.applyRootMotion = false;
        StartMove = true;
    }
}
