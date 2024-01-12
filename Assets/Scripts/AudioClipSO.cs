using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Scripts{

    [CreateAssetMenu(menuName = "SO/AudioClipSO")]
    public class AudioClipSO : ScriptableObject
    {
        [Header("Day->Night")]
        [SerializeField] AudioClip nightCallStart;
        [SerializeField] AudioClip nightCallComplete;

        [Header("CoinPay")]
        [SerializeField] AudioClip startPay;
        [SerializeField] AudioClip excutedPay;
        [SerializeField] AudioClip successPay;

        [Header("Build")]
        [SerializeField] AudioClip successBuild;

        [Header("ArcherShoot")]
        [SerializeField] ClipArray shootSounds;

        [Header("Night->Day")]
        [SerializeField] AudioClip victory;
        [SerializeField] AudioClip repair;
        [SerializeField] ClipArray addCoins;
        [SerializeField] AudioClip defeat;

        [Serializable]
        public class ClipArray
        {
            public AudioClip[] clips;

            public AudioClip GetRandomClip()
            {
                return clips[UnityEngine.Random.Range(0, clips.Length)];
            }
        }
        public AudioClip NightCallStart => nightCallStart;
        public AudioClip NightCallComplete => nightCallComplete;

        public AudioClip StartPay => startPay;
        public AudioClip ExcutedPay => excutedPay;
        public AudioClip SuccessPay => successPay;

        public AudioClip SuccessBuild => successBuild;

        public ClipArray ShootSounds => shootSounds;

        public AudioClip Victory => victory;

        public AudioClip Repair => repair;

        public ClipArray AddCoins => addCoins;

        public AudioClip Defeat => defeat;


    }
    
}
