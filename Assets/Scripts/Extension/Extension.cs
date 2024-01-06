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

        public static Vector3 getRandomPos(float i)
        {
            return new Vector3(Random.Range(-i, i) , Random.Range(-i,i));
        }
    }
    
}
