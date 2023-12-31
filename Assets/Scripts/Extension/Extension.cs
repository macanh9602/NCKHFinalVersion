using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Extension{
    
    public static class Extension
    {      
       public static Vector2 getMousePosition()
       {
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
       }

        public static Vector3 getRandomPos()
        {
            return new Vector3(Random.Range(-1, 1) , Random.Range(-1,1));
        }
    }
    
}
