using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{

    [CreateAssetMenu(menuName = "SO/BuildingTypeSO")]
    public class BuildingTypeSO : ScriptableObject
    {
        public string nameBuilding;
        public Transform prefabs;
        public float timeBuild;
        public float money;

    }



}
