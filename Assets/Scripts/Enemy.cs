using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts{
    
    public class Enemy : MonoBehaviour
    {
        public static Enemy OnCreate(EnemyTypeSO enemy , Vector3 pos)
        {
            //xac dinh enemy pref
            Transform pfEnemy = Resources.Load<Transform>("Enemy");
            //instantiate no 
            pfEnemy = Instantiate(pfEnemy,pos ,Quaternion.identity);
            // getComponent Enemy 
            Enemy thisEnemy = pfEnemy.GetComponent<Enemy>();
            // return   
            return thisEnemy;
        }

        private Transform target;
        private Rigidbody2D rb;
        private Vector3 startPos;
        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            startPos = transform.position;
        }

        private void CheckTarget()
        {
            Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 30f, LayerMask.GetMask("Building"));
            if (collider.Length > 0)
            {
                target = collider[0].gameObject.transform;
            }
            else
            {
                //giu nguyen vi tri  neu ko co muc tieu trong tam
                target = transform;
            }
            //Debug.Log(target.gameObject.name);
        }

        private void Update()
        {
            if (target != null)
            {
                Vector3 vectorNormalize = (target.position - transform.position).normalized;
                float speed = UnityEngine.Random.Range(0.5f, 1f);
                
                rb.velocity = vectorNormalize * speed;
                float distanceMax = Vector3.Distance(target.position, startPos);
                float currentDistance = Vector3.Distance(transform.position, startPos);
                //Debug.Log(distanceMax + "halo" + currentDistance);
                if (distanceMax - currentDistance <= 1f )
                {
                    rb.velocity = new Vector3(0,0,0);
                }
            }
            else
            {
                CheckTarget();

            }
            // Debug.Log(BuildingManager.Instance.getCastleCenter());     
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == 6)
            {
                HealthSysterm health = collision.gameObject.GetComponent<HealthSysterm>();
                health.OnDamage(20f);
                //health.IsHealthChange();        

                Destroy(gameObject);
                // isdestroy = true;
            }
        }

    }

}
