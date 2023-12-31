using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts{
    [CreateAssetMenu(menuName = "SO/EnemyTypeSO")]
    public class EnemyTypeSO : ScriptableObject
    {
        public string nameEnemy;
        public Transform prefabs;
        public float damage;
        public float health;
        public BuildingTypeSO target;
    }
    
}
