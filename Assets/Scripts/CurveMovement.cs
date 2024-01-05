using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts{
    
    public class CurveMovement : MonoBehaviour
    {
        //do cong 2 chieeu time va do cao
        [SerializeField] AnimationCurve curve;

        //thoi gian
        [SerializeField] float duration;

        //do cao 
        [SerializeField] float heightY;
        float t;

        public IEnumerator Curve(Vector3 start, Vector3 end)
        {
            t += Time.deltaTime;
            if (t >= (duration - 0.1f))
            {
                t = duration;
            }
            while (t <= duration)
            {
                //tinh toan do cao theo curve vaf duration
                float heightCurrent = curve.Evaluate(t / duration) * heightY;
                this.gameObject.transform.position = Vector3.Lerp(start, end, t / duration) + new Vector3(0, heightCurrent);  //+ do cao;
                yield return null;
            }
        }
    }
    
}
