using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

namespace Scripts{
    
    public class DayNightCycle
    {
        public IDayNight currentTimeState { get; private set; }
        public Day dayState;
        public Night nightState;
        public DayNightCycle(DayNightController player)
        {
            // create an instance for each state and pass in PlayerController
            this.dayState = new Day(player);
            this.nightState = new Night(player);
        }
        public event Action<IDayNight> stateChanged;

        //khoi tao time state khoi dau
        public void initialize(IDayNight state)
        {
            currentTimeState = state;
            state.Enter();
            stateChanged?.Invoke(state);
        }

        public void TransitionTo(IDayNight nextTimeState)
        {
            currentTimeState.Exit();
            currentTimeState = nextTimeState;
            currentTimeState.Enter();
            stateChanged?.Invoke(nextTimeState);
        }

        public void update()
        {
            currentTimeState.Excute();
        }

    }
    
}
