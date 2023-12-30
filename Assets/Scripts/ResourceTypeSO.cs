using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts{

    [CreateAssetMenu(menuName = "SO/ResourceTypeSO")]

    public class ResourceTypeSO : ScriptableObject
    {
        public string nameResource;
        public string description;
        public Transform prefab;
    }
    
}
