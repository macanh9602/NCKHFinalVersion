﻿using DG.Tweening;
//using Scripts.ObjectPool;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
using UnityEngine.Pool;
//using static UnityEngine.Rendering.ObjectPool<T>;


    public class Arrow : MonoBehaviour, IPoolable<Arrow>
    {
        private EnemyBase target;
        private Vector3 pos;
        private Vector3 lastEnemyPosition;
        private Vector3 direction;
        private ArcherController currentArcher;
        private float _lifetime = 2f;


        private ObjectPool<Arrow> objectPool;

        //curve
        //do cong 2 chieeu time va do cao
        [SerializeField] AnimationCurve curve;

        //thoi gian
        [SerializeField] float duration;

        //do cao 
        [SerializeField] float heightY;
        float t;


        // public property to give the projectile a reference to its ObjectPool
        public ObjectPool<Arrow> ObjectPool { set => objectPool = value; }
        public void Initialize(Action<Arrow> returnAction)
        {

        }
        public void ReturnToPool()
        {

        }
        public void Init(EnemyBase target, Vector3 pos, ObjectPool<Arrow> _pool, ArcherController current)
        {

            //Debug.Log(target);
            this.target = target;
            this.pos = pos;
            objectPool = _pool;
            currentArcher = current;
            this.gameObject.SetActive(true);

        }

        private void Awake()
        {

        }
        private void Start()
        {

            currentArcher.OnCreateArrow += OnCreateArrow;

        }

        public void OnCreateArrow()
        {
            Debug.Log(target);
            if (target != null && objectPool != null)
            {
                //transform.position += normalize * 3 * time.deltatime;
                //startcoroutine()
                StartCoroutine(Curve(pos, target.transform.position));
            }
        }

        private void Update()
        {
            Move();
            ChangeRotation();
            //transform.getcomponent<curvemovement>().move(pos, lastenemyposition);
            SetTimeToDestroy();
        }
        public IEnumerator Curve(Vector3 start, Vector3 end)
        {
            if (t >= (duration - 0.1f))
            {
                t = duration;
            }
            while (t <= duration)
            {
                t += Time.deltaTime;
                //Debug.Log(t);
                //tinh toan do cao theo curve vaf duration
                float heightCurrent = curve.Evaluate(t / duration) * heightY;
                this.gameObject.transform.position = Vector3.Lerp(start, end, t / duration) + new Vector3(0, heightCurrent);  //+ do cao;
                yield return null;
            }
        }

        public void Move()
        {
            //can vi tri cua target
            //huong
            //dk neu enemy bi destroy
            if (target != null)
            {
                direction = (target.transform.position - pos).normalized;
                lastEnemyPosition = target.transform.position;
            }
            else
            {
                if (lastEnemyPosition == transform.position)
                {
                    Destroy(gameObject);
                }
                direction = (lastEnemyPosition - pos).normalized;
                //Debug.Log(lastEnemyPosition);

            }
        }

        public void ChangeRotation()
        {
            float zIndex = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, zIndex);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (target != null)
            {
                if (collision.gameObject.tag == target.gameObject.tag)
                {
                    //Debug.Log("halo");
                    HealthSysterm health = collision.GetComponent<HealthSysterm>();
                    health.OnDamage(currentArcher.TD.CanDamaging.damage);
                    //health.IsHealthChange();
                    Destroy();
                }
            }

        }
        private void SetTimeToDestroy()
        {
            _lifetime -= Time.deltaTime;
            if (_lifetime <= 0)
            {
                //Destroy(gameObject);
                Destroy();
                _lifetime = 2;
            }
        }
        private void Destroy()
        {
            t = 0f;
            target = null;
            transform.position = pos;
            objectPool.Push(this);
        }
    }


