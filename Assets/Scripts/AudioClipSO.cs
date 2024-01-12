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
        [SerializeField] AudioClip[] shootSounds;

        [Header("Night->Day")]
        [SerializeField] AudioClip victory;
        [SerializeField] AudioClip repair;
        [SerializeField] AudioClip[] addCoins;
        [SerializeField] AudioClip lose;

    }
    
}
