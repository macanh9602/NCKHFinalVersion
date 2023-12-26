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
        public void Build(BuildingTypeSO buildingType , Vector3 pos)
        {
            Debug.Log("halo");
            Transform building = Instantiate(buildingType.prefabs, pos, Quaternion.identity);
            //building.SetParent(currentBuildingTypeHolder.gameObject.transform);
           // building.GetComponent<SpriteRenderer>().sprite = buildingType.sprite[Random.Range(0, buildingType.sprite.Length)];
            //building.GetComponent<CoinGenerator>().buildingType = buildingType;
        }
    }
    
}
