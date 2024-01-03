using Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

namespace Scripts{
    
    public class PosBuildingController : MonoBehaviour
    {
        public BuildingTypeSO buildingType;
        //[SerializeField] bool IsBuild = false;

        //private void OnTriggerStay2D(Collider2D collision)
        //{
        //    if(collision.tag == "Player")
        //    {
        //        //goi ham tao hieu ung xay dung
        //        //tinh tien
        //        if(Input.GetKey(KeyCode.Space) && IsBuild == false ) 
        //        {
        //            Debug.Log("halo");
        //            gameObject.SetActive(false);
        //            BuildingConstruction building = BuildingConstruction.Create(buildingType, this.transform.position);
        //            Manager.ResourceManager.Instance.CalculateCost((int)buildingType.money);
        //            IsBuild = true;
        //            //Debug.Log(this.transform.position);
        //        }

        //    }
        //}

    }
    
}
//private void OnTriggerStay2D(Collider2D collision)
//{
//    if (collision.tag == "Player")
//    {
//        //goi ham tao hieu ung xay dung
//        //tinh tien
//        if (Input.GetKey(KeyCode.Space) && IsBuild == false)
//        {
//            Debug.Log("halo");
//            gameObject.SetActive(false);
//            BuildingConstruction building = BuildingConstruction.Create(buildingType, this.transform.position);
//            Manager.ResourceManager.Instance.CalculateCost((int)buildingType.money);
//            IsBuild = true;
//            //Debug.Log(this.transform.position);
//        }

//    }
//}
