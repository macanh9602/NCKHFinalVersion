using Scripts.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts{
    
    public class BuildingConstruction : MonoBehaviour
    {
        //1 lop static tao hieu ung co tham so truyen vao la buidlingtype va vi tri (tu gameobject chua component
        //posbuildingcontroller)
        public static BuildingConstruction Create(BuildingTypeSO buildingType, Vector3 pos)
        {
            Transform pfbuildingConstruction = Resources.Load<Transform>("BuildingConstruction");
            //Debug.Log(pos);
            pfbuildingConstruction = Instantiate(pfbuildingConstruction , pos , Quaternion.identity);
            BuildingConstruction buildingConstruction = pfbuildingConstruction.gameObject.GetComponent<BuildingConstruction>();
            buildingConstruction.setup(buildingType, pos);
            //Debug.Log(buildingConstruction.transform.position);
            Debug.Log(buildingType.name);
            return buildingConstruction;
        }

        //depend qua constructor
        BuildingTypeSO buildingType;
        Vector3 pos;
        float time;
        public void setup(BuildingTypeSO buildingType , Vector3 pos)
        {
            this.buildingType = buildingType;
            this.pos = pos;
        }

        private void Start()
        {
            time = buildingType.timeBuild;
           
        }

        private void Update()
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                //transform.Find("clip1").GetComponent<Animator>().enabled = false;
                BuildingManager.Instance.Build(buildingType, this.transform.position);
                Destroy(gameObject);
            }
            //Debug.Log(NormalizeTimeBuild());
        }

        public float NormalizeTimeBuild()
        {
            return time / buildingType.timeBuild;
        }
    }
    
}
