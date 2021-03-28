using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class MyCarSub : MonoBehaviour
{
    public bool isStart = false;
    public string[] sentences;

     public float startDelayTime;
    public float delayTime;

    public Text _backText;
    public Text _frontText;

    public MyCarsController carsController;

     public MyCarController carController;


    private AudioSource _audio;

    public delegate void EndTalkDelegate();

    public event EndTalkDelegate EndTalkHandler;


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
        foreach(string s in sentences){
            _backText.text = s;
            _frontText.text = s;
            if(index == 1){
                carsController.IsStart = true;
            }
            if(index == 4){
                carController.nextWayPoint = true;
            }
            yield return new WaitForSeconds(delayTime);
            if(index == 3){
                _audio.Play();
                yield return new WaitForSeconds(2.5f);
            }
            index++;
        }
        _backText.text = "";
        _frontText.text = "";
        if(EndTalkHandler != null){
            EndTalkHandler();
        }

    }
}
