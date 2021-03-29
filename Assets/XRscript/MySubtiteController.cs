using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MySubtiteController : MonoBehaviour
{
    public bool isStart = false;
    public string[] sentences;

    public float startDelayTime;
    public float delayTime;

    public Text _backText;
    public Text _frontText;

    public delegate void EndTalkDelegate();

    public event EndTalkDelegate EndTalkHandler;

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
        foreach(string s in sentences){
            _backText.text = s;
            _frontText.text = s;
            yield return new WaitForSeconds(delayTime);
        }
        _backText.text = "";
        _frontText.text = "";
        if(EndTalkHandler != null){
            EndTalkHandler();
        }

    }

    

}
