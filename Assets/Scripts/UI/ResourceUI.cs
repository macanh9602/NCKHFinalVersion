using System.Collections;
using System.Collections.Generic;
using System.Resources;
using TMPro;
using UnityEngine;

    public class ResourceUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI myCoin;
        private void Start()
        {
            UpdateCoinUI();

            ResourceManager.Instance.OnCoinChange += Instance_OnCoinChange;
        }

        private void Instance_OnCoinChange(object sender, System.EventArgs e)
        {
            UpdateCoinUI();
        }
        public void UpdateCoinUI()
        {
            string text = ResourceManager.Instance.getResourceAmount().ToString();
            myCoin.text = text;
        }
    }
    

