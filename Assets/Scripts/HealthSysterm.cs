
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
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
                Debug.Log(gameObject.name);
                if(gameObject.name == "Enemy_B(Clone)")
                {
                    EnemyManager.Instance.addEnemiesDie(1);
                }
                else if(gameObject.name == "House(Clone)")
                {
                    BuildingManager.Instance.UpdateCurrentHouseAmount(-1);
                }
                //if(this.gameObject.name == "")
                return true;
            }
            else return false;
        }

    }


