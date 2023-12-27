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
        private float time2;
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
            time2 = Time.time;
        }
        
        private void OnStateChanged(IDayNight obj)
        {
            if(obj == dayNightCycle.nightState)
            {
                //time += Time.deltaTime * timeSpeed;
                //Debug.Log(time % 1);
                //light2d.color = gradient.Evaluate(time % 1);\
                StartCoroutine(UpdateTime());

            }
        }

        private IEnumerator UpdateTime()
        {
            while (dayNightCycle.currentTimeState == dayNightCycle.nightState)
            {
                time += Time.deltaTime * timeSpeed;
                Debug.Log(time % 1);
                light2d.color = gradient.Evaluate(time % 1);
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
//[SerializeField] private Gradient gradient;
//private Light2D light2d;
//private float time;
//private float timeSpeed = 0.2f;
//private void Awake()
//{
//    light2d = GetComponent<Light2D>();
//}

//private void Update()
//{
//    time += Time.deltaTime * timeSpeed;
//    light2d.color = gradient.Evaluate(time % 1);
//}