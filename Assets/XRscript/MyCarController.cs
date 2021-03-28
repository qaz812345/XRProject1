using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MyCarController : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform[] targets;

    public MyAIIKcontroller ik;

    public bool nextWayPoint;

    private int currentIndex;
    private bool stopTrigger = false;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentIndex = 0;
        agent.SetDestination(targets[currentIndex].position);
        currentIndex += 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.remainingDistance < 0.1 && stopTrigger == false){
            stopTrigger = true;
            ik.GiveBeer();
        }


        if(nextWayPoint){
            agent.SetDestination(targets[currentIndex].position);
        }
    }

}
