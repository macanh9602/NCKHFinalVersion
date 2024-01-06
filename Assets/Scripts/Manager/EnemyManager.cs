using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Manager{
    
    public class EnemyManager : MonoBehaviour
    {
        public EnemyTypeSO enemyType;
        public List<Transform> pos;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            //sua lai thanh dieu kien khi ban ngay ket thuc , man dem bat dau
            if (Input.GetMouseButtonDown(0))
            {
                //Enemy.Create(Extension.MousePosition(), enemyType);
                Enemy.OnCreate(enemyType , pos[Random.Range(0, pos.Count)].position  + Extension.Extension.getRandomPos(1));
            }
        }
    }
    
}
