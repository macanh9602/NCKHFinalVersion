using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts{
    
    public static class Extension
    {      
       public static Vector2 getMousePosition()
       {
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
       }

        public static Vector2 getRandomPos()
        {
            return new Vector2(Random.Range(-2, 2) , Random.Range(-2,2));
        }
    }
    
}
