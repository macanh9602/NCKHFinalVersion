using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.DayNightStateMachine
{

    public class DayNightController : MonoBehaviour
    {
        private IDayNight currentState;
        public IDayNight CurrentState => currentState;
        public event Action<IDayNight> OnDayNightStateChange;

        //public void StartState(IDayNight currentState)
        //{
        //    this.currentState = currentState;
        //    currentState?.Enter(this);
        //}
        public void TranstitionToState(IDayNight nextState)
        {
            currentState?.Exit(this);
            currentState = nextState;
            currentState?.Enter(this);
            //StartCoroutine(EnterTime());
            OnDayNightStateChange?.Invoke(currentState);
        }

        //IEnumerator EnterTime()
        //{
        //    if (currentState.GetType() == typeof(NightState))
        //    {
        //        currentState?.Enter(this);
        //        yield return null;
        //    }
        //    else if (currentState.GetType() == typeof(DayState))
        //    {
        //        yield return new WaitForSeconds(3f);
        //        currentState?.Enter(this);
        //    }
        //}
        IEnumerator EnterTime()
        {
            yield return new WaitForSeconds(3f);
            currentState?.Enter(this);
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
