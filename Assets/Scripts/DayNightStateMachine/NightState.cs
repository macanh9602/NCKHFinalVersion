using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.DayNightStateMachine{
    
    public class NightState : IDayNight
    {
        private PlayerMovement player;
        public NightState(PlayerMovement player)
        {
            this.player = player;
        }
        public void Enter(DayNightController dayNightController)
        {

        }

        public void Excuted(DayNightController dayNightController)
        {

        }
        public void Exit(DayNightController dayNightController)
        {

        }
    }
    
}
