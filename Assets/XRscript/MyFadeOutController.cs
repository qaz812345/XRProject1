using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyFadeOutController : MonoBehaviour
{
    public float TimeLength;

    public bool isStart = false;

    public bool switchAfterDonw = false;

    private Image _blackImage;

    private Color _black;
    private float _accTime;
    private bool _isSwiched;

    // Start is called before the first frame update
    void Start()
    {
        _blackImage = GetComponent<Image>();
        _black = Color.black;
        _isSwiched = false;
    }

    // Update is called once per frame
    void Update()
    {
         if(isStart){
            _accTime += Time.deltaTime;
            if(_accTime <= TimeLength){
                _black.a = _accTime/TimeLength;
                _blackImage.color = _black;
            }else{
                if(_isSwiched == false && switchAfterDonw == true){
                    MySceneManager.SwitchToNextScene();
                    _isSwiched = true;
                }
            }
        }
    }
}
