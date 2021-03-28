using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharacterDrivign : MonoBehaviour
{
    private Animator _anim;
    private AudioSource _audio;

    public AudioClip[] clips;

    public float StartTime;

    public float SecondEndTime;

    private bool firstSongEnd = false;
    private bool secondSongEnd = false;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
        _audio.clip = clips[0];
        _audio.time = StartTime;
        _audio.Play();
        //_audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(!_audio.isPlaying && firstSongEnd == false){
            firstSongEnd = true;
            _audio.clip = (clips[1]);
            _audio.time = 0;
            _audio.Play();
        }
        if(firstSongEnd == true && _audio.time > 20 && secondSongEnd == false){
            secondSongEnd = true;
            _anim.SetTrigger("OnTurnoffRadio");
        }
    }

    public void StopRadio(){
        _audio.Stop();
        // _audio.clip = (clips[1]);
        // _audio.time = 0;
        // _audio.Play();
    }
}
