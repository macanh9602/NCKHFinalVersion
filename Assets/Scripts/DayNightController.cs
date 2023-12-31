using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts{
    
    public class DayNightController : MonoBehaviour
    {
        private DayNightCycle dayNightCycle;
        public DayNightCycle DayNightCycle => dayNightCycle;

        private float requiredPressTime = 5f;
        private void Awake()
        {
            dayNightCycle = new DayNightCycle(this);
        }
        // Start is called before the first frame update
        void Start()
        {
            dayNightCycle.initialize(dayNightCycle.dayState); //
        }

        // Update is called once per frame
        void Update()
        {
            dayNightCycle.update(); //

            //if (Input.GetKey(KeyCode.Space))
            //{
            //    //StartCoroutine(WaitForSpacePress());
            //    float elapsedTime = 0f;

            //    while (elapsedTime < requiredPressTime)
            //    {
            //        elapsedTime += Time.deltaTime;
            //        //yield return null;
            //    }
            //    Debug.Log(elapsedTime);
            //    if (elapsedTime >= requiredPressTime)
            //    {
            //        //Debug.Log(elapsedTime);
            //        // Chạy logic khi người dùng giữ phím Space trong 5 giây
            //        player.DayNightCycle.TransitionTo(player.DayNightCycle.nightState);
            //    }

            //}
        }

    }

}
