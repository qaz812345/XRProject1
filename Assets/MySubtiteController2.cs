using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MySubtiteController2 : MonoBehaviour
{
    public bool isStart = false;

  
    private int _sentIndex = 0;
    public string[] sentences;

  
    public AudioClip[] clips;

    public float[]  stayTime;

    public float startDelayTime;
    public float delayTime;

    public Text _backText;
    public Text _frontText;

    public delegate void EndTalkDelegate();

    public event EndTalkDelegate EndTalkHandler;

    private AudioSource audioSource;

    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
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
            audioSource.clip = clips[0];
            audioSource.Play();
             _sentIndex = 0;
            foreach(string s in sentences){
                _backText.text = s;
                _frontText.text = s;
                //audioSource.clip = clips[_sentIndex];
                //audioSource.Play();
                if(_sentIndex == 4){
                    audioSource.clip = clips[1];
                    audioSource.Play();
                }
                if(_sentIndex == 6){
                    audioSource.clip = clips[2];
                    audioSource.Play();

                }
                  if(_sentIndex == 9){
                    audioSource.clip = clips[3];
                    audioSource.Play();

                }
                yield return new WaitForSeconds(stayTime[_sentIndex]);
                _sentIndex++;
                
            }
        
        _backText.text = "";
        _frontText.text = "";
        if(EndTalkHandler != null){
            EndTalkHandler();
        }

    }
}
