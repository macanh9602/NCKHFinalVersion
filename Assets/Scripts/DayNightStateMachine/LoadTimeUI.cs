using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts{

    public class LoadTimeUI : MonoBehaviour
    {
        [SerializeField] TMP_Text timerText;
        [SerializeField] Image imgLoad;
        [SerializeField] Image imgType;
        [SerializeField] Image imgTypeStandard;
        private Sprite imgStandard;
        [SerializeField] Ease ease;
        private RectTransform rectTransform;
        public static LoadTimeUI instance { get; private set; }

        private void Awake()
        {
            instance = this;
            timerText.text = "";
            this.gameObject.SetActive(false);
            imgStandard = imgType.sprite;
            rectTransform = GetComponent<RectTransform>();
        }

        public void UpdateTimer(float timerValue, float timeNormalize, bool IsTouchPosBuilding , BuildingTypeSO buildingType)
        {
            this.gameObject.SetActive(true);
            if (timerText != null && imgLoad != null)
            {
                setText(timerValue, IsTouchPosBuilding);
                setCircleLoad(timeNormalize);
                setImageType(buildingType);
                if (timeNormalize > 1)
                {
                    this.gameObject.SetActive(false);
                }
            }

        }

        private void setCircleLoad(float timeNormalize)
        {
            imgLoad.fillAmount = timeNormalize;
        }

        private void setText(float timerValue, bool IsTouchPosBuilding)
        {
            if (IsTouchPosBuilding)
            {
                timerText.text = "CurrentPayCoin : " + timerValue.ToString("F0");
            }
            else timerText.text = "Night in " + timerValue.ToString("F1");
        }
        private void setImageType(BuildingTypeSO buildingType)
        {
            if (buildingType == null)
                imgType.sprite = imgStandard;
            else imgType.sprite = buildingType.icon;
        }
        public void setUILoad(bool isActiveUI , bool isNightCallComplete)
        {
            if(isNightCallComplete == false)
            {
                this.gameObject.SetActive(isNightCallComplete);
            }
            else
            {
                rectTransform.DOScale(new Vector3(2,2,2),3f).SetEase(ease).OnComplete(() => { 
                this.gameObject.SetActive(isActiveUI); });
            }
            
        }
        
    }
    
}
