
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VTLTools;

    
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] float speed = 10f;
        private HealthSysterm health;
        DayNightController dayNightController;
        public PosBuildingController currentPosBuilding;
        public Action<PosBuildingController> OnChangeCurrentPosBuilding;
        public float costBuilding;
        public bool soundNightOn = false;

        private float t;
        private void Awake()
        {
            dayNightController = GetComponent<DayNightController>();
            dayNightController.TranstitionToState(new DayState(this));
            //dayNightController.StartState(new DayState(this));
        }
        // Start is called before the first frame update
        void Start()
        {
            health = GetComponent<HealthSysterm>();
        }
    
        // Update is called once per frame
        void Update()
        {
            Move();
            dayNightController.Excuted();
            #region <----soundBG---->
            //if (dayNightController.CurrentState.GetType() == typeof(NightState) )
            //{
            //    if(t <= 2f)
            //    {
            //        t += Time.deltaTime;
            //    }
            //    if (!soundNightOn && t >2f)
            //    {
            //        Manager.SoundManager.Instance.PlaySound(Manager.SoundManager.Instance.ClipSO.SoundNight);
            //        soundNightOn = true;
            //    }

            //}
            //if(dayNightController.CurrentState.GetType() == typeof(DayState))
            //{
            //    t = 0f;
            //    soundNightOn = false;
            //}
            #endregion
        }

        private void Move()
        {
            float xInput = Input.GetAxisRaw("Horizontal");
            float yInput = Input.GetAxisRaw("Vertical");
            transform.position += new Vector3(xInput , yInput , 0 ).normalized * speed * Time.deltaTime;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer(StringsSafeAccess.LAYER_SLOT_NAME))
            {
                costBuilding = collision.GetComponent<PosBuildingController>().buildingType.money;
                currentPosBuilding = collision.GetComponent<PosBuildingController>();
                OnChangeCurrentPosBuilding?.Invoke(currentPosBuilding);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer(StringsSafeAccess.LAYER_SLOT_NAME))
            {
                currentPosBuilding = null;
                OnChangeCurrentPosBuilding?.Invoke(currentPosBuilding);
            }
        }

    }
    