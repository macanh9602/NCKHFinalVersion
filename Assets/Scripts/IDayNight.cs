using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Scripts{
    
    public interface  IDayNight
    {
        public void Enter();
        public void Excute();
        public void Exit();
    }

    public class Day : IDayNight
    {
        private DayNightController player;
        public Day(DayNightController player)
        {
            this.player = player;
        }
        //xử lý logic ban ngay
        public void Enter()
        {
            //
        }

        public void Excute()
        {
            if(Input.GetKey(KeyCode.Z))
            {
                player.DayNightCycle.TransitionTo(player.DayNightCycle.nightState);
                Debug.Log("halo");
            }
        }

        public void Exit()
        {
            //
        }
        
    }

    public class Night : IDayNight
    {
        private DayNightController player;

        public Night(DayNightController player)
        {
            this.player = player;
        }
        //xử lý logic ban dem
        public void Enter()
        {
            //
        }

        public void Excute()
        {
            //
        }

        public void Exit()
        {
            //
        }

    }

}
