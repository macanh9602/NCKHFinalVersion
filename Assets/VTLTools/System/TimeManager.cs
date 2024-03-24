using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VTLTools;

namespace AntiStress
{
    public class TimeManager : Singleton<TimeManager>
    {
        [SerializeField] float playTime;
        [SerializeField] bool isCounting;

        [ShowInInspector]
        public double SaleTimeRemain
        {
            get;
            private set;
        }
        private void Update()
        {
            if (isCounting)
                playTime += Time.deltaTime;

            if (StaticVariables.IsSaleTime)
            {
                SaleTimeRemain = (StaticVariables.EndTimeSale - DateTime.Now).TotalSeconds;

                if (SaleTimeRemain <= 0)
                    StaticVariables.IsSaleTime = false;
            }
        }

        public void StartCounting()
        {
            isCounting = true;
        }

        public float GetPlayTime()
        {
            float _playTime = playTime;
            isCounting = false;
            playTime = 0;
            return _playTime;
        }
    }
}