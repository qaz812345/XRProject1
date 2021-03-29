using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharacterAddForce : MonoBehaviour
{
    public bool IsAddForce;
    public Vector3 forceMag;

    private Rigidbody rb;

    public MySubtiteController mySubtiteController;

    public MySubtiteController mySubtiteControllerInWater;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mySubtiteController.EndTalkHandler += AddForce;
        
    }
    
      void Update()
    {
        if( IsAddForce){
             IsAddForce = false;
             AddForce();
        }
    }

    // Update is called once per frame
    public void AddForce(){
        rb.AddForce(forceMag);
        mySubtiteControllerInWater.isStart = true;
    }

    public void AdjustDrag(){
        rb.drag = 8;
    }
}
