using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts{
    
    public class Arrow : MonoBehaviour
    {
        public static Arrow OnCreate(Transform target ,  Vector2 pos)
        {
            //prf
            Transform pfArrow = Resources.Load<Transform>("Enemy");
            //
            Transform Arrow  = Instantiate(pfArrow,pos , Quaternion.identity);
            //
            Arrow arrow = Arrow.GetComponent<Arrow>();
            return arrow;
        } // thieu muc tieu

        private Transform target;
        private Vector2 pos;

        public void setData(Transform target , Vector2 pos)
        {
            this.target = target;
            this.pos = pos;
        }

        private void Update()
        {
            //di chuyen den m,uc tieu
        }

        //ontriggerenter
        //- tru mau + destroy

    }
    
}
