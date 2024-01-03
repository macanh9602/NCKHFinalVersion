using Scripts.DayNightStateMachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts{
    
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] float speed = 10f;
        private HealthSysterm health;
        DayNightController dayNightController;
        public PosBuildingController currentPosBuilding;
        public Action<PosBuildingController> OnChangeCurrentPosBuilding;
        public float costBuilding;
        private void Awake()
        {
            dayNightController = GetComponent<DayNightController>();
            dayNightController.TranstitionToState(new DayState(this));
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
            //Debug.Log((dayNightController.currentState));
            //if (health != null && Input.GetKeyDown(KeyCode.Q))
            //{
            //    health.OnDamage(30f);
            //}



        }

        private void Move()
        {
            float xInput = Input.GetAxisRaw("Horizontal");
            float yInput = Input.GetAxisRaw("Vertical");
            transform.position += new Vector3(xInput , yInput , 0 ).normalized * speed * Time.deltaTime;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.layer == 7)
            {
                costBuilding = collision.GetComponent<PosBuildingController>().buildingType.money;
                currentPosBuilding = collision.GetComponent<PosBuildingController>();
                OnChangeCurrentPosBuilding?.Invoke(currentPosBuilding);
            }
            
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.layer == 7)
            {
                currentPosBuilding = null;
                OnChangeCurrentPosBuilding?.Invoke(currentPosBuilding);
            }    
        }

    }
    
}
