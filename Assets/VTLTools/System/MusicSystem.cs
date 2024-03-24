using System.Collections;
using System.Collections.Generic;
using VTLTools;
using UnityEngine;


namespace AntiStress
{
    public class MusicSystem : Singleton<MusicSystem>
    {
        [SerializeField] private AudioSource musicAudioSource;
        [SerializeField] AudioClip defaultThemeMusic;
        [SerializeField] List<AudioClip> noelThemeMusicList;


        private void OnEnable()
        {
            musicAudioSource.mute = !StaticVariables.IsMusicOn;
        }

        public void ToggeMusic()
        {
            StaticVariables.IsMusicOn = !StaticVariables.IsMusicOn;
            musicAudioSource.mute = !StaticVariables.IsMusicOn;
        }

        public void LowerVolume()
        {
            musicAudioSource.volume = 0.3f;
        }

        public void SetVolumeToDefault()
        {
            musicAudioSource.volume = 1;
        }

        public void SetMusicVolume(float _value)
        {
            musicAudioSource.volume = _value;
        }

        public void PlayDefaultThemeMusic()
        {
            if (musicAudioSource.clip != defaultThemeMusic)
            {
                musicAudioSource.clip = defaultThemeMusic;
                musicAudioSource.Play();
            }
        }
        public void PlayNoelThemeMusic()
        {
            musicAudioSource.clip = noelThemeMusicList[Random.Range(0, noelThemeMusicList.Count)];
            musicAudioSource.Play();
        }
    }
}