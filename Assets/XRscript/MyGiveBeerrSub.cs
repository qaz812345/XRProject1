using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyGiveBeerrSub : MonoBehaviour
{
    //public bool isStart = false;

    
    public string sentence;
    public Text _backText;
    public Text _frontText;


    public void SetSub(bool value){
        if(value == true){
            _backText.text = sentence;
            _frontText.text = sentence;
        }else{
            _backText.text = "";
            _frontText.text = "";
            
        }
    }
}
