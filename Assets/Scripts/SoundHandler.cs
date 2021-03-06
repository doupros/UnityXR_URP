﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is the sound feedback for the keyboard - Hemi
/// </summary>

public class SoundHandler : MonoBehaviour
{
    public AudioClip keyClick;
    private AudioSource clickSource;

    // Start is called before the first frame update
    void Start()
    {
        clickSource = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayOnClick()
    {
        clickSource.PlayOneShot(keyClick);  
    }
}
