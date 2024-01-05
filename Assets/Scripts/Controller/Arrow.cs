using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Scripts.Controller{
    
    public class Arrow : MonoBehaviour
    {
        public static Arrow OnCreate(Enemy target ,  Vector3 pos , ArcherController currentArcher)
        {
            //prf
            Transform pfArrow = Resources.Load<Transform>("Arrow");
            //
            Transform Arrow  = Instantiate(pfArrow,pos , Quaternion.identity);

            //
            Arrow arrow = Arrow.GetComponent<Arrow>();
            //
            arrow.setData(target,pos,currentArcher);
            return arrow;
        } // thieu muc tieu

        private Enemy target;
        private Vector3 pos;
        private Vector3 lastEnemyPosition;
        private Vector3 normalize;
        private ArcherController currentArcher;
        private float time = 3f;

        public void setData(Enemy target , Vector3 pos , ArcherController currentArcher)
        {
            this.target = target;
            this.pos = pos;
            this.currentArcher = currentArcher;
        }

        private void Update()
        {
            //di chuyen den m,uc tieu
            //di chuyen
            Move();
            //Debug.Log(lastEnemyPosition);
            //dich chuyen theo farme

            //transform.position += normalize * speed * Time.deltaTime;

            StartCoroutine(gameObject.GetComponent<CurveMovement>().Curve(pos, lastEnemyPosition));

            ChangeRotation();
            SetTimeToDestroy();
        }

        //ontriggerenter
        //- tru mau + destroy
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
                    HealthSysterm health = collision.GetComponent<HealthSysterm>();
                    health.OnDamage(currentArcher.TD.CanDamaging.damage);
                    //health.IsHealthChange();
                    //Debug.Log("hha");
                    Destroy(gameObject);
                }
            }

        }
        private void SetTimeToDestroy()
        {
            time -= Time.deltaTime;
            if (time < 0)
            {
                Destroy(gameObject);

            }
        }

    }
    
}
