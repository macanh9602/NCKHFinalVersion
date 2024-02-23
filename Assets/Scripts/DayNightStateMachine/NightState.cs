﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.DayNightStateMachine
{

    public class NightState : IDayNight
    {
        private PlayerMovement player;

        [SerializeField] int enemiesMaxAmount = 10;
        [SerializeField] int enemiesDieAmount;
        public NightState(PlayerMovement player)
        {
            this.player = player;
        }
        public void Enter(DayNightController dayNightController)
        {
            Manager.SoundManager.Instance.PlaySoundOnShot(Manager.SoundManager.Instance.ClipSO.NightCallComplete);
        }

        public void Excuted(DayNightController dayNightController)
        {
            enemiesDieAmount = Manager.EnemyManager.Instance.EnemiesDieAmount;
            //Debug.Log(enemiesDieAmount);
            if (enemiesDieAmount >= enemiesMaxAmount)
            {
                //transtition to day
                dayNightController.TranstitionToState(new DayState(player));
                //reset
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                dayNightController.TranstitionToState(new DayState(player));
            }
        }
        public void Exit(DayNightController dayNightController)
        {
            Manager.SoundManager.Instance.StopSound();
            Manager.SoundManager.Instance.PlaySoundOnShot(Manager.SoundManager.Instance.ClipSO.Victory);
            ResetAfterNight();
        }

        private void ResetAfterNight()
        {
            enemiesDieAmount = 0;
            player.soundNightOn = false;
        }
    }

}
