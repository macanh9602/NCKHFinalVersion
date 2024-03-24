
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using VTLTools;
//using static UnityEditor.PlayerSettings;
//using static UnityEngine.Rendering.ObjectPool<T>;
//using static UnityEngine.Rendering.ObjectPool<T>;



    public class ArcherController : MonoBehaviour
    {
        [SerializeField] BuildingTypeSO td;
        [SerializeField] Transform PosSpawn;

        [SerializeField] GameObject pfArrow;
        [SerializeField] AudioSource audioSource;
        private EnemyBase targetEnemy;
        private float timeCheck;
        private float timeCheckMax = .3f;

        private float timeSpawnDistance;
        private float timeSpawnDistanceMax = .2f;
        private float distanceCheck = 4f;
        public bool CanSeeEnemy = false;
        private ObjectPool<Arrow> objectPool;
        public Action OnCreateArrow;
        public BuildingTypeSO TD => td;
        private void Awake()
        {
            objectPool = new ObjectPool<Arrow>(this.transform , pfArrow, OnPullObject, OnPushObject, 10);
        }
        private void OnPullObject(Arrow obj)
        { 
            obj.Init(targetEnemy, this.transform.position, objectPool, this);
            obj.gameObject.SetActive(true);

        }

        private void OnPushObject(Arrow obj)
        {
            targetEnemy = null;
            obj.gameObject.SetActive(false);
            // Logic tùy chỉnh khi đưa đối tượng trở lại pool
        }

        public void Update()
        {
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
                Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, distanceCheck, LayerMask.GetMask(StringsSafeAccess.LAYER_ENEMY_NAME));
                CanSeeEnemy = colliders.Length > 0 ? true : false;
                //tao vong lap cac colli enemy
                if (colliders.Length == 0) return;
                if (colliders.Length > 0)
                {
                    //Debug.Log(colliders[0].gameObject.GetComponent<Enemy>().name);
                    targetEnemy = colliders[0].gameObject.GetComponent<EnemyBase>();
                }
                else
                {
                    foreach (Collider2D collider in colliders)
                    {
                        ////tao enemy moi , gan no voi collider
                        EnemyBase enemy = collider.gameObject.GetComponent<EnemyBase>();
                        if(targetEnemy == null && enemy != null)
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
                    //Debug.Log(targetEnemy.name);
                    Arrow arrow = objectPool.Pull();
                    audioSource.PlayOneShot(SoundManager.Instance.ClipSO.ShootSounds.GetRandomClip());
                    arrow.transform.position = this.transform.position;
                    OnCreateArrow?.Invoke();
                }
            }

        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, distanceCheck);
        }
    }



//target 1 cua archer ben ngoai , debug target 2 cua tk dau tien