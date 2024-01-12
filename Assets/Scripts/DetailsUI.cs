using DG.Tweening;
using Scripts.Controller;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Scripts
{

    public class DetailsUI : MonoBehaviour
    {
        [SerializeField] TMP_Text textName;
        [SerializeField] TMP_Text textDetails;
        [SerializeField] PlayerMovement player;
        // Start is called before the first frame update
        void Start()
        {
            player.OnChangeCurrentPosBuilding += OnChangeCurrentPosBuilding;
            this.gameObject.SetActive(false);
            textDetails.text = "";
        }

        private void OnChangeCurrentPosBuilding(PosBuildingController controller)
        {
            if (controller != null)
            {
                Show(controller);
            }
            else Hide();
        }

        private void Hide()
        {
            //textName.DOFade(0, 1.5f);
            //textDetails.DOFade(0, 1.5f).OnComplete(() => { gameObject.SetActive(false); });
            gameObject.SetActive(false);
        }

        private void Show(PosBuildingController controller)
        {
            gameObject.SetActive(true);
            textName.text = controller.buildingType.nameBuilding;
            textDetails.text = controller.buildingType.details;
            textName.DOFade(1, 1.5f);
            textDetails.DOFade(1, 1.5f);
        }

    }

}
