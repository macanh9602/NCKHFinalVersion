using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    // type of enemy , amount of enemy , time to spawn enemy , position to spawn enemy
    [Serializable]
    public class Spawn
    {

        public EnemyTypeSO enemyTypeSO;
        public int enemyAmount;
        public int enemyBornAmount;
        public int enemyDieAmount;
        public int enemyRemainAmount;
        public float enemySpawnPerSecond;
        public Transform posSpawn;

    }

