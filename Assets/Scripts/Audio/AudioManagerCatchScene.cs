using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManagerCatchScene : MonoBehaviour
{
    public AudioManagerCatchScene instance;
    
    [SerializeField] private AudioClip ballSelectorOpen;
    [SerializeField] private AudioClip ballSelectorClose;
    [SerializeField] private AudioClip touchBall;
    [SerializeField] private AudioClip releaseBall;
    [SerializeField] private AudioClip successSound;
    [SerializeField] private AudioClip failSound;
    [SerializeField] private AudioClip goUpSound;
    [SerializeField] private AudioClip suckSound;
    [SerializeField] private AudioClip tickSound;

    public AudioSource aS;

    private void Awake()
    {
        instance = this;
    }

    public void Update()
    {
        Touch touch = Input.GetTouch(0);

        switch (touch.phase)
        {
            case TouchPhase.Began:
                aS.clip = touchBall;
                aS.Play();
                return;
            case TouchPhase.Ended:
                aS.clip = releaseBall;
                aS.Play();
                return;
                
        }
    }

    public void BallSelectorOpen()
    {
        aS.clip = ballSelectorOpen;
        aS.Play();
    } 
    
    public void BallSelectorClose()
    {
        aS.clip = ballSelectorClose;
        aS.Play();
    }
    
    public void Success()
    {
        aS.clip = successSound;
        aS.Play();
    }
    
    public void Fail()
    {
        aS.clip = failSound;
        aS.Play();
    }
    
    public void GoUp()
    {
        aS.clip = goUpSound;
        aS.Play();
    }
    
    public void Suck()
    {
        aS.clip = suckSound;
        aS.Play();
    } 
    
    public void Tick()
    {
        aS.clip = tickSound;
        aS.Play();
    }
}
