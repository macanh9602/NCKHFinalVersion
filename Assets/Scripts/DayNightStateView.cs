using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Scripts{
    
    public class DayNightStateView : MonoBehaviour
    {
        [SerializeField] private Gradient gradient;
        private Light2D light2d;
        private float time;
        private float timeSpeed = 0.2f;
        private DayNightCycle dayNightCycle;
        private DayNightController playerMovement;
        private void Awake()
        {
            playerMovement = GetComponent<DayNightController>();
            light2d = GetComponent<Light2D>();
            dayNightCycle = playerMovement.DayNightCycle;
            if(dayNightCycle != null)
            {
                dayNightCycle.stateChanged += OnStateChanged; //
            }
            else
            {
                Debug.Log("halo");
            }
        }
        
        private void OnStateChanged(IDayNight obj)
        {
            if(obj == dayNightCycle.nightState)
            {
                StartCoroutine(ExcuteNightView());
            }
            else if (obj == dayNightCycle.dayState)
            {
                StartCoroutine(ExecuteDayView());
            }
        }

        private IEnumerator ExcuteNightView()
        {
            while (dayNightCycle.currentTimeState == dayNightCycle.nightState && time < 1f)
            {
                time += Time.deltaTime * timeSpeed;
                
                light2d.color = gradient.Evaluate(time / 1f);
                if(time >= 0.99f)
                {
                    time = 1f;
                }
                Debug.Log(time);
                yield return null;
            }
        }

        private IEnumerator ExecuteDayView()
        {
            while (dayNightCycle.currentTimeState == dayNightCycle.dayState && time > 0f)
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
        // Start is called before the first frame update
        void Start()
        {
            
        }
    
        // Update is called once per frame
        void Update()
        {
            
        }
    }
    
}
