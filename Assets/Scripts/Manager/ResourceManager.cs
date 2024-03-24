using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

    public class ResourceManager : MonoBehaviour
    {
        public static ResourceManager Instance {  get; private set; }

        [SerializeField] private ResourceTypeSO resource;
        public Dictionary<ResourceTypeSO, int> _coin = new Dictionary<ResourceTypeSO, int>();
        //action
        public event EventHandler OnCoinChange;
        private void Awake()
        {
            Instance = this;
            _coin[resource] = 100;
        }

        public void AddResourceAmount(int buildingAliveAmount)
        {
            _coin[resource] += buildingAliveAmount;
            OnCoinChange?.Invoke(this,EventArgs.Empty);
        }

        public int getResourceAmount()
        {
            return _coin[resource];
        }

        public void CalculateCost(int cost)
        {
            _coin[resource] -= cost;
            OnCoinChange?.Invoke(this, EventArgs.Empty);
        }
    }
