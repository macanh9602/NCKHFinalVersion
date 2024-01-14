using Scripts.Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Manager{
    
    public class BuildingManager : MonoBehaviour
    {
        [SerializeField] int currentHouseAmount;
        public static BuildingManager Instance {  get; private set; }

        private void Start()
        {
            Instance = this;
        }
        public void Build(BuildingTypeSO buildingType , Vector3 pos , Controller.PosBuildingController posBuilding)
        {
            //Debug.Log("halo");
            Transform building = Instantiate(buildingType.prefabs, pos, Quaternion.identity);
            //building.GetComponent<HouseController>
            Manager.SoundManager.Instance.PlaySound(Manager.SoundManager.Instance.ClipSO.SuccessBuild);
            //Debug.Log(buildingType.GetType() + " / " + buildingType.GetType().Name);
            Debug.Log(buildingType.name);
            if(buildingType.name == "HouseSO")
            {
                //add house
                Debug.Log("halo");
                UpdateCurrentHouseAmount(1);
            }
        }
        public void UpdateCurrentHouseAmount(int number)
        {
            currentHouseAmount += number;
        }

        public int getCurrentHouseAmount()
        {
            return currentHouseAmount;
        }
    }
    
}
