using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Manager{
    
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] EnemyTypeSO enemyType;
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
                Enemy.OnCreate(enemyType , pos[UnityEngine.Random.Range(0, pos.Count)].position  + Extension.Extension.getRandomPos(1));
            }
            CheckEnemyAmount();
        }

        public void addEnemiesDie(int i)
        {
            enemiesDieAmount += i;
        }
        private void CheckEnemyAmount()
        {
            //GameObject[] object1 = GameObject.FindGameObjectsWithTag("Enemy");
            //Debug.Log(object1.Length);
            //so luong enemies bi destroy
        }
    }
    
}
