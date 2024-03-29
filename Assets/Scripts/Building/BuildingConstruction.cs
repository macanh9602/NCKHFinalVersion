﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    
    public class BuildingConstruction : MonoBehaviour
    {
        public static BuildingConstruction Create(BuildingTypeSO buildingType, Vector3 pos , PosBuildingController posBuilding)
        {
            Transform pfbuildingConstruction = Resources.Load<Transform>("BuildingConstruction");
            //Debug.Log(pos);
            pfbuildingConstruction = Instantiate(pfbuildingConstruction , pos , Quaternion.identity);
            BuildingConstruction buildingConstruction = pfbuildingConstruction.gameObject.GetComponent<BuildingConstruction>();
            buildingConstruction.setup(buildingType, pos , posBuilding);
            //Manager.SoundManager.Instance.PlaySound(Manager.SoundManager.Instance.ClipSO.SuccessPay);
            return buildingConstruction;
        }

        //depend qua constructor
        BuildingTypeSO buildingType;
        Vector3 pos;
        float time;
        PosBuildingController posBuilding;
        public void setup(BuildingTypeSO buildingType , Vector3 pos , PosBuildingController posBuilding)
        {
            this.buildingType = buildingType;
            this.pos = pos;
            this.posBuilding = posBuilding;
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
                BuildingManager.Instance.Build(buildingType, this.transform.position , posBuilding);
                Destroy(gameObject);
            }
            //Debug.Log(NormalizeTimeBuild());
        }

        public float NormalizeTimeBuild()
        {
            return time / buildingType.timeBuild;
        }
    }
    
