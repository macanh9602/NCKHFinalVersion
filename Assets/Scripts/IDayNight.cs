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

    public class Day :  IDayNight
    {
        private DayNightController player;
        private float requiredPressTime= 5f;
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
            if (Input.GetKey(KeyCode.Space))
            {
                //StartCoroutine(WaitForSpacePress());
                float elapsedTime = 0f;

                while (elapsedTime < requiredPressTime)
                {
                    elapsedTime += Time.deltaTime;
                    //yield return null;
                }
                Debug.Log(elapsedTime);
                if (elapsedTime >= requiredPressTime)
                {
                    //Debug.Log(elapsedTime);
                    // Chạy logic khi người dùng giữ phím Space trong 5 giây
                    player.DayNightCycle.TransitionTo(player.DayNightCycle.nightState);
                }

            }
        }

        private IEnumerator WaitForSpacePress()
        {
            float elapsedTime = 0f;

            while ( elapsedTime < requiredPressTime)
            {
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            if (elapsedTime >= requiredPressTime)
            {
                // Chạy logic khi người dùng giữ phím Space trong 5 giây
                player.DayNightCycle.TransitionTo(player.DayNightCycle.nightState);
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
            if (Input.GetKey(KeyCode.X))
            {
                player.DayNightCycle.TransitionTo(player.DayNightCycle.dayState);

            }
        }

        public void Exit()
        {
            //
        }

    }

}
