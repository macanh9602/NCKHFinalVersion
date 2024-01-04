using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts{
    
    public class LoadTimeUI : MonoBehaviour
    {
        public TMP_Text timerText;
        public Image img;
        public static LoadTimeUI instance {  get; private set; }

        private void Awake()
        {
            instance = this;
            timerText.text = "";
            this.gameObject.SetActive(false);
        }

        public void UpdateTimer(float timerValue , float timeNormalize , bool IsTouchPosBuilding)
        {
            this.gameObject.SetActive(true);
            if (timerText != null && img != null)
            {
                if (IsTouchPosBuilding)
                {
                    timerText.text = "CurrentPayCoin : " + timerValue.ToString("F0");
                }
                else timerText.text = "Night in " + timerValue.ToString("F1");
                img.fillAmount = timeNormalize;
                if (timeNormalize > 1)
                {
                    this.gameObject.SetActive(false);
                }
            }
            
        }

        public void setUILoad(bool IsOke)
        {
            this.gameObject.SetActive(IsOke);
        }
        
    }
    
}
