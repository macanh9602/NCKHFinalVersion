using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Manager{
    
    public class SoundManager : MonoBehaviour
    {

        [SerializeField] AudioClipSO clipSO;
        private AudioSource audioSource;
        public AudioClipSO ClipSO => clipSO;

        public static SoundManager Instance { get; private set; }
        private void Start()
        {
            Instance = this;
            audioSource = GetComponent<AudioSource>();
        }

        public void PlaySound(AudioClip audio)
        {
            audioSource.PlayOneShot(audio);
        }

        public void StopSound()
        {
            audioSource.Stop();
        }
    
    }
    
}
