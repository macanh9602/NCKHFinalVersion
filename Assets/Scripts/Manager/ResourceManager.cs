using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Manager{
    
    public class ResourceManager : MonoBehaviour
    {
        public static ResourceManager Instance {  get; private set; }

        [SerializeField] private ResourceTypeSO resource;
        public Dictionary<ResourceTypeSO, int> _coin = new Dictionary<ResourceTypeSO, int>();
        //action
        private void Awake()
        {
            Instance = this;
            _coin[resource] = 100;
        }

        public void AddResourceAmount(int buildingAliveAmount)
        {
            _coin[resource] += buildingAliveAmount;
        }

        public int getResourceAmount()
        {
            return _coin[resource];
        }
    }
    
}
