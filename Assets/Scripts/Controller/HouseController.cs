using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Controller{
    
    public class HouseController : MonoBehaviour
    {
        [SerializeField] BuildingTypeSO m_BuildingType;
        public BuildingTypeSO HouseSO => m_BuildingType;
        // Start is called before the first frame update
        private void Update()
        {
            if(gameObject.GetComponent<HealthSysterm>().IsDie() == true)
            {
                Debug.Log("1");
                Manager.BuildingManager.Instance.UpdateCurrentHouseAmount(-1);
            }
        }

    }
    
}
