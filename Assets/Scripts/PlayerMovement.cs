using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts{
    
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] float speed = 10f;
        //private DayNightCycle dayNightCycle; 
        //public DayNightCycle DayNightCycle => dayNightCycle;
        private HealthSysterm health;


        private void Awake()
        {
            //dayNightCycle = new DayNightCycle(this);
        }
        // Start is called before the first frame update
        void Start()
        {
            //dayNightCycle.initialize(dayNightCycle.dayState); //
            health = GetComponent<HealthSysterm>();
        }
    
        // Update is called once per frame
        void Update()
        {
            Move();
            //dayNightCycle.update(); //

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

       
    }
    
}
