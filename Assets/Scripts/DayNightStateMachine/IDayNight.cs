using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    
    public interface IDayNight
    {
        public void Enter(DayNightController dayNightController);
        public void Excuted(DayNightController dayNightController);
        public void Exit(DayNightController dayNightController);

    }

