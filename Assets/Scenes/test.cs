using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scenes{
    
    public class test : MonoBehaviour
    {
        [SerializeField] RectTransform rectTransform;
        // Start is called before the first frame update
        void Start()
        {
            rectTransform.DOScale(new Vector3(3, 3, 3), 2f).SetEase(Ease.InBounce);
            
        }
    
        // Update is called once per frame
        void Update()
        {
            
        }
    }
    
}
