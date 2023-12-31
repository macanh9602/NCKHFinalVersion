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
            UpdateCoinUI();

            Manager.ResourceManager.Instance.OnCoinChange += Instance_OnCoinChange;
        }

        private void Instance_OnCoinChange(object sender, System.EventArgs e)
        {
            UpdateCoinUI();
        }
        public void UpdateCoinUI()
        {
            string text = Manager.ResourceManager.Instance.getResourceAmount().ToString();
            transform.Find("Coin_text_UI").GetComponent<TextMeshProUGUI>().text = text;
        }
    }
    
}
