using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using VTLTools;

public class EnemyBase : MonoBehaviour
{
    public static EnemyBase OnCreate(EnemyTypeSO enemy, Vector3 pos)
    {
        ResourceAsset<Transform> pfEnemy = new ResourceAsset<Transform>(enemy.nameEnemy);
        Transform enemyPrefab = pfEnemy.Value;
        enemyPrefab = Instantiate(enemyPrefab, pos, Quaternion.identity);
        EnemyBase thisEnemy = enemyPrefab.GetComponent<EnemyBase>();
        return thisEnemy;
    }

    [SerializeField] protected SpriteRenderer spriteRenderer;
    [SerializeField] protected float distanceCheck = 20f;
    [SerializeField] protected Rigidbody2D rb;
    private Transform target;

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (target != null)
        {
            Vector3 vectorNormalize = (target.position - transform.position).normalized;
            float speed = UnityEngine.Random.Range(0.5f, 1f);

            rb.velocity = vectorNormalize * speed;
            //float distanceMax = Vector3.Distance(target.position, startPos);
            //float currentDistance = Vector3.Distance(transform.position, startPos);
            FlipFace();
        }
        else
        {
            CheckTarget();

        }
    }

    private void FlipFace()
    {
        if (target.position.x > transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    private void CheckTarget()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, distanceCheck, LayerMask.GetMask("Building"));
        if (collider.Length == 0) return;
        if (collider.Length > 0)
        {
            if (collider.Length == 1)
            {
                target = collider[0].gameObject.transform;
            }
            else
            {
                //target is collider if distance is shortest
                float distance = Vector3.Distance(transform.position, collider[0].transform.position);
                for (int i = 1; i < collider.Length; i++)
                {
                    float distanceTemp = Vector3.Distance(transform.position, collider[i].transform.position);
                    if (distanceTemp < distance)
                    {
                        distance = distanceTemp;
                        target = collider[i].gameObject.transform;
                    }
                }
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            HealthSysterm health = collision.gameObject.GetComponent<HealthSysterm>();
            health.OnDamage(200f);
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distanceCheck);
    }
}


