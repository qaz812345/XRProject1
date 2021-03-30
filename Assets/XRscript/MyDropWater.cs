using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDropWater : MonoBehaviour
{
    private bool IsDrop = false;
    public MyCharacterAddForce characterAddForce;

    public MyFadeOutController fadeOutController;

    public float FadeOutDelayTime = 2.0f;

    private AudioSource _source;

    public AudioSource BGMwater;

    public AudioSource BGMInwater;

    void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    void OnTriggerStay(Collider other)
    {
        if(!IsDrop && other.tag.Equals("Character")){
           IsDrop = true;
           _source.Play();
           BGMInwater.Play();
           BGMwater.Stop();
           characterAddForce.AdjustDrag();
           StartCoroutine(startFade());
        }
    }

    IEnumerator startFade(){
        yield return new WaitForSeconds(FadeOutDelayTime);
        fadeOutController.isStart = true;
    }

    

}
