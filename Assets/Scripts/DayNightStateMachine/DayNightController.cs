using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.DayNightStateMachine {
    
    public class DayNightController : MonoBehaviour
    {
        public IDayNight currentState;
        public event Action<IDayNight> OnDayNightStateChange;
        
        public void TranstitionToState(IDayNight nextState)
        {
            currentState?.Exit(this);
            currentState = nextState;
            currentState?.Enter(this);
            OnDayNightStateChange?.Invoke(currentState);
        }

        public void Excuted()
        {
            currentState?.Excuted(this);
        }

        public IDayNight getCurrentState()
        {
            return currentState;
        }
    }
    
}
