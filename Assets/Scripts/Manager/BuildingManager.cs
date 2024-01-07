using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Manager{
    
    public class BuildingManager : MonoBehaviour
    {
        public static BuildingManager Instance {  get; private set; }

        private void Start()
        {
            Instance = this;
        }
        public void Build(BuildingTypeSO buildingType , Vector3 pos , Controller.PosBuildingController posBuilding)
        {
            //Debug.Log("halo");
            Transform building = Instantiate(buildingType.prefabs, pos, Quaternion.identity);
            //building.transform.parent = posBuilding.transform;
        }
    }
    
}
