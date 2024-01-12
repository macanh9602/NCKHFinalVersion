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
        private float timeSpeed = 0.5f;
        public PlayerMovement player;
        private DayNightController dayNightController;
        [SerializeField] List<Transform> lstTorch;

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
                StartCoroutine(ExecuteDayView());
            }
            else if (currentState.GetType() == typeof(NightState))
            {
                StartCoroutine(ExcuteNightView());
            }
        }

        private void TurnOnLight()
        {
            foreach(Transform go in lstTorch)
            {
                //Debug.Log("halo");
                go.Find("Light").gameObject.SetActive(true);
            }
        }

        private IEnumerator ExcuteNightView()
        {
            while (dayNightController.CurrentState.GetType() == typeof(NightState) && time < 1f)
            {
                time += Time.deltaTime * timeSpeed;

                light2d.color = gradient.Evaluate(time / 1f);
                if (time >= 0.99f)
                {
                    time = 1f;
                    TurnOnLight();
                }
                yield return null;
            }
        }

        private IEnumerator ExecuteDayView()
        {
            while (dayNightController.CurrentState.GetType() == typeof(DayState) && time > 0f)
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
