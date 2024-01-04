using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Scripts.DayNightStateMachine{
    
    public class DayNightStateView : MonoBehaviour
    {
        [SerializeField] private Gradient gradient;
        private Light2D light2d;
        private float time;
        private float timeSpeed = 0.2f;
        public PlayerMovement player;
        private DayNightController dayNightController;

        private void Start()
        {
            light2d = GetComponent<Light2D>();

            dayNightController = player.GetComponent<DayNightController>();
            player.GetComponent<DayNightController>().OnDayNightStateChange += DayNightStateView_OnDayNightStateChange;
        }

        private void DayNightStateView_OnDayNightStateChange(IDayNight currentState)
        {
            if(currentState.GetType() == typeof(DayState))
            {
                StartCoroutine(ExcuteNightView());
            }
            else if (currentState.GetType() == typeof(NightState))
            {
                StartCoroutine(ExcuteNightView());
            }
        }

        private IEnumerator ExcuteNightView()
        {
            while (dayNightController.currentState.GetType() == typeof(NightState) && time < 1f)
            {
                time += Time.deltaTime * timeSpeed;

                light2d.color = gradient.Evaluate(time / 1f);
                if (time >= 0.99f)
                {
                    time = 1f;
                }
                yield return null;
            }
        }

        private IEnumerator ExecuteDayView()
        {
            while (dayNightController.currentState.GetType() == typeof(DayState) && time > 0f)
            {
                time -= Time.deltaTime * timeSpeed; // Giảm dần thời gian

                light2d.color = gradient.Evaluate(time / 1f);

                if (time <= 0.01f)
                {
                    time = 0f;
                }

                Debug.Log(time);
                yield return null;
            }
        }
    }
    
}
