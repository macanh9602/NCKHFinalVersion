using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] EnemyTypeSO[] enemiesType;
        [SerializeField] List<Transform> pos;
        [SerializeField] int enemiesDieAmount;
        public int EnemiesDieAmount => enemiesDieAmount;

        public static EnemyManager Instance { get; private set; }

        

        // Start is called before the first frame update
        private void Start()
        {
            Instance = this;

        }

        // Update is called once per frame
        private void Update()
        {
            //sua lai thanh dieu kien khi ban ngay ket thuc , man dem bat dau
            if (Input.GetMouseButtonDown(0))
            {
                //Enemy.Create(Extension.MousePosition(), enemyType);
                EnemyBase.OnCreate(enemiesType[0], pos[UnityEngine.Random.Range(0, pos.Count)].position  + Extension.getRandomPos(1));
            }
        }

        public void addEnemiesDie(int i)
        {
            enemiesDieAmount += i;
        }
    }

