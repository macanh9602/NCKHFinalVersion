using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts{
    
    public class GhostController : MonoBehaviour
    {
        [SerializeField] private PlayerMovement player;

        private void Awake()
        {
            player.OnChangeCurrentPosBuilding += OnChangeCurrentPosBuilding;
            Hide();
        }

        public void OnChangeCurrentPosBuilding(PosBuildingController currentPosBuilding)
        {
            if(currentPosBuilding != null)
            {
                if(currentPosBuilding.IsBuild == false)
                Show(currentPosBuilding);
                else Hide();
            }
            else Hide();

        }

        public void Hide()
        {
            this.transform.gameObject.SetActive(false);
        }

        public void Show(PosBuildingController current)
        {
            this.transform.gameObject.SetActive(true);
            transform.Find("sprite").GetComponent<SpriteRenderer>().sprite = current.buildingType.sprite;
            this.transform.position = current.transform.position;
        }
    }
    
}
