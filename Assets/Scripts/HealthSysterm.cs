using Scripts.Manager;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Scripts
{

    public class HealthSysterm : MonoBehaviour
    {
        [SerializeField] float healthMax;
        private float currentHealth;
        public event EventHandler OnHealthChange;
        public float CurrentHealth => currentHealth;
        private void Start()
        {
            currentHealth = healthMax;
        }
        public void OnDamage(float damage)
        {
            currentHealth -= damage;
            //Debug.Log(currentHealth);
            currentHealth = Mathf.Clamp(currentHealth, 0, healthMax);
            if (IsDie())
            {
                Destroy(gameObject);
            }
            OnHealthChange?.Invoke(this, EventArgs.Empty);
        }

        public float HealthRatio()
        {
            return currentHealth / healthMax;
        }

        public bool IsDie()
        {
            if (currentHealth <= 0)
            {
                if(this.gameObject.GetComponent<Enemy>().GetType() == typeof(Enemy))
                {
                    Manager.EnemyManager.Instance.addEnemiesDie(1);
                    Debug.Log("hahah");
                }
                return true;
            }
            else return false;
        }

    }
}

