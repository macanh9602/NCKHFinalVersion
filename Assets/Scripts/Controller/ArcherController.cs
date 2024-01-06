using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Controller{
    
    public class ArcherController : MonoBehaviour
    {
        //check enemy
        //sinh arrow
        Enemy targetEnemy;
        [SerializeField] BuildingTypeSO td;
        private float timeCheck;
        private float timeCheckMax = .2f;

        private float timeSpawnDistance;
        private float timeSpawnDistanceMax = .4f;

        [SerializeField] Transform PosSpawn;
        public bool CanSeeEnemy = false;
        public BuildingTypeSO TD => td;

        private void Start()
        {
            //tower = GetComponent<ThisTypeOfBuilding>().towerDefense;
        }
        public void Update()
        {
            //timeSpawnDistanceMax = tower.SpawnArrowPerTime;
            CheckEnemy();
            if (CanSeeEnemy == true)
            {
                SpawnArrow();
            }

        }

        public void CheckEnemy()
        {
            timeCheck -= Time.deltaTime;
            if (timeCheck <= timeCheckMax)
            {
                timeCheck += timeCheckMax;
                //check now
                Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 5f, LayerMask.GetMask("Monster"));
                CanSeeEnemy = colliders.Length > 0 ? true : false;
                //tao vong lap cac colli enemy
                foreach (Collider2D collider in colliders)
                {
                    //tao enemy moi , gan no voi collider
                    Enemy enemy = collider.gameObject.GetComponent<Enemy>();

                    //gan enemyTarget vao 1 trong enemy tuong ung collider trong colliders[] theo dk
                    if (colliders[0].gameObject.GetComponent<Enemy>() == enemy)
                    {
                        //chua co thi gan
                        targetEnemy = enemy;
                    }
                    else
                    {
                        //    //khoang cach voi doi tuong voi target thu i
                        float iDistance = Vector3.Distance(transform.position, targetEnemy.transform.position);
                        //    //khoang cach voi doi tuong voi target thu j
                        float jDistance = Vector3.Distance(transform.position, enemy.transform.position);
                        //    //co roi thi thay doi theo dieu kien la khoang cach
                        if (jDistance < iDistance)
                        {
                            targetEnemy = enemy;
                        }
                    }
                }

                //if(colliders.Length > 0 )
                //{
                //    targetEnemy = colliders[0].gameObject.GetComponent<Enemy>();
                //}

            }
        }
        public void SpawnArrow()
        {
            if (targetEnemy is not null)
            {
                timeSpawnDistance -= Time.deltaTime;
                if (timeSpawnDistance <= 0)
                {
                    timeSpawnDistance = timeSpawnDistanceMax;
                    //sinh now
                    Arrow.OnCreate(targetEnemy , PosSpawn.position , this);
                    //Debug.Log("k");
                }
            }

        }
    }
    
}
