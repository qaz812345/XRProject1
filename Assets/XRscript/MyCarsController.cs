using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCarsController : MonoBehaviour
{
    public bool IsStart = false;
    public float speed = 5.0f;

    private Vector3 v = new Vector3(1,0,0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(IsStart == true){
            transform.position += v * speed * Time.deltaTime;
        }
    }
}
