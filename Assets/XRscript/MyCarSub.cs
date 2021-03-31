using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class MyCarSub : MonoBehaviour
{
    public bool isStart = false;
    public string[] sentences;

    public float[] stayTime;
    public AudioSource longTalkAudioSource;
    public AudioClip[] clips;

     public float startDelayTime;
    public float delayTime;

    public Text _backText;
    public Text _frontText;

    public MyCarsController carsController;

     public MyCarController carController;


    private AudioSource _audio;

    public delegate void EndTalkDelegate();

    public event EndTalkDelegate EndTalkHandler;

    public MyAIIKcontroller aIIKcontroller;


    private int index=0;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }
    
    // Start is called before the first frame update
   void Update()
    {
        if(isStart == true){
            StopAllCoroutines();
            isStart = false;
            StartCoroutine(startPlay());
        }
    }

    IEnumerator startPlay(){
        yield return new WaitForSeconds (startDelayTime);
        longTalkAudioSource.clip = clips[0];
        longTalkAudioSource.Play();
        foreach(string s in sentences){
            _backText.text = s;
            _frontText.text = s;
            if(index == 2){
                carsController.IsStart = true;
                aIIKcontroller.IsLookAt = true;
            }
           
            if(index == 4){
                longTalkAudioSource.clip = clips[2];
                longTalkAudioSource.Play();
                carController.nextWayPoint = true;
            }
             if(index == 3){
                longTalkAudioSource.clip = clips[1];
                longTalkAudioSource.Play();
                yield return new WaitForSeconds(7f);
                _audio.Play();
                 aIIKcontroller.IsLookAt = false;
               
            }
            yield return new WaitForSeconds(stayTime[index]);
            index++;
        }
        _backText.text = "";
        _frontText.text = "";
        if(EndTalkHandler != null){
            EndTalkHandler();
        }

    }
}
