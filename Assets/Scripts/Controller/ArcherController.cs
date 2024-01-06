
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

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
        private float timeSpawnDistanceMax = .3f;

        [SerializeField] Transform PosSpawn;
        public bool CanSeeEnemy = false;
        public BuildingTypeSO TD => td;

        [SerializeField] Arrow pfArrow;
        //create local pool
        private IObjectPool<Arrow> objectPool;

        private void Awake()
        {
            objectPool = new ObjectPool<Arrow>(CreateProjectile,
                OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject,
                true, 20, 100);
        }

        // invoked when creating an item to populate the object pool
        private Arrow CreateProjectile()
        {
            Arrow projectileInstance = Instantiate(pfArrow);
            projectileInstance.ObjectPool = objectPool;
            return projectileInstance;
        }

        // invoked when returning an item to the object pool
        private void OnReleaseToPool(Arrow pooledObject)
        {
            pooledObject.gameObject.SetActive(false);
        }

        // invoked when retrieving the next item from the object pool
        private void OnGetFromPool(Arrow pooledObject)
        {
            pooledObject.gameObject.SetActive(true);
        }

        // invoked when we exceed the maximum number of pooled items (i.e. destroy the pooled object)
        private void OnDestroyPooledObject(Arrow pooledObject)
        {
            Destroy(pooledObject.gameObject);
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

            }
        }
        public void SpawnArrow()
        {
            if (targetEnemy is not null && objectPool != null)
            {
                timeSpawnDistance -= Time.deltaTime;
                if (timeSpawnDistance <= 0)
                {
                    timeSpawnDistance = timeSpawnDistanceMax;
                    Arrow arrow = objectPool.Get();
                    if (arrow == null)
                        return;
                    //bat buoc set vi tri truoc roi moi bat arrow
                    arrow.transform.position = PosSpawn.position;
                    arrow.Init(targetEnemy , objectPool);

                }
            }

        }
    }
    
}
