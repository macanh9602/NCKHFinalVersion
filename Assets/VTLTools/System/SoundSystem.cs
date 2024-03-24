using System.Collections;
using System.Collections.Generic;
using VTLTools;
using UnityEngine;


namespace AntiStress
{
    public class SoundSystem : Singleton<SoundSystem>
    {
        [SerializeField] AudioSource shareAudioSource;
        [SerializeField] AudioSource uIAudioSource;
        [SerializeField] AudioClip uIOnClickAudioClip;


        public void PlaySoundOneShot(AudioClip _audioClip, float _level)
        {
            if (!StaticVariables.IsSoundOn)
                return;
            else
                shareAudioSource.PlayOneShot(_audioClip, _level);
        }

        public void PlaySoundOneShot(AudioClip _audioClip)
        {
            if (!StaticVariables.IsSoundOn)
                return;
            else
                shareAudioSource.PlayOneShot(_audioClip);
        }
        public void PlaySoundOneShot(AudioSource _audioSource, AudioClip _audioClip)
        {
            if (!StaticVariables.IsSoundOn)
                return;
            else
                _audioSource.PlayOneShot(_audioClip);
        }

        public void PlaySoundOneShot(AudioSource _audioSource, AudioClip _audioClip, float _volume)
        {
            if (!StaticVariables.IsSoundOn)
                return;
            else
                _audioSource.PlayOneShot(_audioClip, _volume);
        }

        public void PlayUIClick()
        {
            if (!StaticVariables.IsSoundOn)
                return;
            else
                uIAudioSource.PlayOneShot(uIOnClickAudioClip);
        }

        //public void ToggleSound()
        //{
        //    StaticVariables.IsSoundOn = !StaticVariables.IsSoundOn;
        //    EventDispatcher.Instance.Dispatch(EventName.OnToggleSoundSetting, null);
        //}
    }
}