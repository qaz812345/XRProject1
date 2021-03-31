using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGravityRunTime : MonoBehaviour
{
    public Vector3 gravityThisScene;
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = gravityThisScene;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
