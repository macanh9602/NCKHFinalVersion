using DG.Tweening;
using Scripts.ObjectPool;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
using UnityEngine.Pool;

namespace Scripts.Controller
{

    public class Arrow : MonoBehaviour
    {
        //public static Arrow OnCreate(Enemy target ,  Vector3 pos , ArcherController currentArcher)
        //{
        //    //prf
        //    Transform pfArrow = Resources.Load<Transform>("Arrow");
        //    //
        //    Transform Arrow  = Instantiate(pfArrow,pos , Quaternion.identity);

        //    //
        //    Arrow arrow = Arrow.GetComponent<Arrow>();
        //    //
        //    //arrow.setData(target,pos,currentArcher);
        //    return arrow;
        //} // thieu muc tieu

        private Enemy target;
        private Vector3 pos;
        private Vector3 lastEnemyPosition;
        private Vector3 normalize;
        private ArcherController currentArcher;
        private float _lifetime = 3f;
        //private PooledObject pooledObject;
        //private ObjectPool<Arrow> _pool;

        private IObjectPool<Arrow> objectPool;

        // public property to give the projectile a reference to its ObjectPool
        public IObjectPool<Arrow> ObjectPool { set => objectPool = value; }

        //public void setData(Enemy target , Vector3 pos , ArcherController currentArcher , ObjectPool<Arrow> pool)
        //{
        //    this.target = target;
        //    this.pos = pos;
        //    this.currentArcher = currentArcher;
        //    //_pool = pool;
        //    gameObject.SetActive(true);
        //    //Invoke(nameof(Destroy), _lifetime);
        //    //invoke
        //}

        public void Init(Enemy target , IObjectPool<Arrow> _pool)
        {
            this.target = target;
            objectPool = _pool;
            gameObject.SetActive(true);
        }

        private void Awake()
        {
            //pooledObject = GetComponent<PooledObject>();
        }

        private void Update()
        {
            //di chuyen den m,uc tieu
            //di chuyen
            Move();

            //Debug.Log(lastEnemyPosition);
            //dich chuyen theo farme

            //transform.position += normalize * speed * Time.deltaTime;

            StartCoroutine(gameObject.GetComponent<CurveMovement>().Curve(pos, lastEnemyPosition 
            + Extension.Extension.getRandomPos(0.1f)));
            //transform.DOMove(target.transform.position,2f);

            //ChangeRotation();
            SetTimeToDestroy();
        }

        public void Move()
        {
            //can vi tri cua target
            //huong
            //dk neu enemy bi destroy
            if (target != null)
            {
                normalize = (target.transform.position - pos).normalized;
                lastEnemyPosition = target.transform.position;
            }
            else
            {
                if (lastEnemyPosition == transform.position)
                {
                    Destroy(gameObject);
                }
                normalize = (lastEnemyPosition - pos).normalized;
                //Debug.Log(lastEnemyPosition);

            }




        }

        public void ChangeRotation()
        {
            float zIndex = Mathf.Atan2(normalize.y, normalize.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, zIndex);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (target != null)
            {
                if (collision.gameObject.tag == target.gameObject.tag)
                {
                    Debug.Log("halo");
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
            }
        }
        private void Destroy()
        {
            objectPool.Release(this);

        }
    }


}
