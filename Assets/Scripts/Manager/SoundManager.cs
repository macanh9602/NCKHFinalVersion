using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
   
    public class SoundManager : MonoBehaviour
    {

        [SerializeField] AudioClipSO clipSO;
        private AudioSource audioSource;
        public AudioClipSO ClipSO => clipSO;

        public AudioSource AudioSource => audioSource;
        public static SoundManager Instance { get; private set; }
        private void Start()
        {
            Instance = this;
            audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            
        }

        public void PlaySoundOnShot(AudioClip audio)
        {
            audioSource.PlayOneShot(audio);
        }

        public void PlaySound(AudioClip audio)
        {
            audioSource.clip = audio;
            audioSource.Play();
        }

        public void StopSound()
        {
            audioSource.Stop();
        }
    
    }

