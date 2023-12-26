using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts{
    
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] float speed = 10f;
        // Start is called before the first frame update
        void Start()
        {
            
        }
    
        // Update is called once per frame
        void Update()
        {
            Move();
        }

        private void Move()
        {
            float xInput = Input.GetAxisRaw("Horizontal");
            float yInput = Input.GetAxisRaw("Vertical");
            transform.position += new Vector3(xInput , yInput , 0 ).normalized * speed * Time.deltaTime;
        }
    }
    
}
