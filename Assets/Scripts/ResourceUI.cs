using System.Collections;
using System.Collections.Generic;
using System.Resources;
using TMPro;
using UnityEngine;

namespace Scripts{
    
    public class ResourceUI : MonoBehaviour
    {
        private void Start()
        {         
            Debug.Log(Manager.ResourceManager.Instance.getResourceAmount());
            string text = Manager.ResourceManager.Instance.getResourceAmount().ToString();
            transform.Find("Coin_text_UI").GetComponent<TextMeshProUGUI>().text = text;
        }
    }
    
}
