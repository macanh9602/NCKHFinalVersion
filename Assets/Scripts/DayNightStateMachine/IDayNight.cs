using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.DayNightStateMachine {
    
    public interface IDayNight
    {
        public void Enter(DayNightController dayNightController);
        public void Excuted(DayNightController dayNightController);
        public void Exit(DayNightController dayNightController);

    }
    
}
