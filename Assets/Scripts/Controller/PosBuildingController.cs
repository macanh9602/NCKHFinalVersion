using Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

namespace Scripts.Controller{
    
    public class PosBuildingController : MonoBehaviour
    {
        public BuildingTypeSO buildingType;
        public bool IsBuild = false;

        public void Start()
        {
            if(buildingType.nameBuilding == "Hall")
            {
                IsBuild = true;
            }
        }
        public void setIsBuild()
        {
            IsBuild = true;
        }
    }
    
}

