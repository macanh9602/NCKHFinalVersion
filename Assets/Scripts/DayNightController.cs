using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts{
    
    public class DayNightController : MonoBehaviour
    {
        private DayNightCycle dayNightCycle;
        public DayNightCycle DayNightCycle => dayNightCycle;
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
        }

    }

}
