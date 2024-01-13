
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
//using static UnityEditor.PlayerSettings;
//using static UnityEngine.Rendering.ObjectPool<T>;
//using static UnityEngine.Rendering.ObjectPool<T>;

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
        private float timeSpawnDistanceMax = .2f;

        [SerializeField] Transform PosSpawn;
        public bool CanSeeEnemy = false;
        public BuildingTypeSO TD => td;

        [SerializeField] GameObject pfArrow;
        //create local pool
        //private IObjectPool<Arrow> objectPool;
        //private ObjectPool<Arrow> arrowPool;

        private ObjectPool<Arrow> objectPool;
        public Action OnCreateArrow;

        private void Awake()
        {
            //objectPool = new ObjectPool<Arrow>(CreateProjectile,
            //    OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject,
            //    true, 20, 100);
            objectPool = new ObjectPool<Arrow>(pfArrow, OnPullObject, OnPushObject, 10);
        }
        private void OnPullObject(Arrow obj)
        {
            // Logic tùy chỉnh khi lấy một đối tượng từ pool
            // Bạn có thể tùy chỉnh đối tượng thêm nếu cần
            obj.Init(targetEnemy, this.transform.position, objectPool , this);
            obj.gameObject.SetActive(true);
            
        }

        private void OnPushObject(Arrow obj)
        {
            targetEnemy = null;
            //obj.transform.position = transform.position;
            obj.gameObject.SetActive(false);
            // Logic tùy chỉnh khi đưa đối tượng trở lại pool
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
        //private int count = 1;
        public void SpawnArrow()
        {
            if (targetEnemy is not null && objectPool != null)
            {
                //Debug.Log("halo1");
                timeSpawnDistance -= Time.deltaTime;
                //Debug.Log(timeSpawnDistance);
                if (timeSpawnDistance <= 0)
                {
                    //Debug.Log("halo2");
                    timeSpawnDistance = timeSpawnDistanceMax;
                    Arrow arrow = objectPool.Pull();
                    Manager.SoundManager.Instance.PlaySound(Manager.SoundManager.Instance.ClipSO.ShootSounds.GetRandomClip());
                    //Debug.Log(arrow);
                    //if (arrow == null)
                       // return;
                    //bat buoc set vi tri truoc roi moi bat arrow
                    arrow.transform.position = this.transform.position;
                    OnCreateArrow?.Invoke();
                    
                    //count++;

                }
            }

        }
    }
    
}
