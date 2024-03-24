using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [CreateAssetMenu(menuName = "SO/EnemyTypeSO")]
    public class EnemyTypeSO : ScriptableObject
    {
        public string nameEnemy;
        public Transform prefabs;
        public float damage;
        public BuildingTypeSO target;
    }
    

