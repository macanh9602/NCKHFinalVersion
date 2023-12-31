using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts{
    
    public class HealthSysterm : MonoBehaviour
    {
        [SerializeField] float healthMax;
        private float currentHealth;
        public  event EventHandler OnHealthChange;

        private void Start()
        {
            currentHealth = healthMax;
        }
        public void OnDamage(float damage)
        {
            currentHealth -= damage;
            Debug.Log(currentHealth);
            currentHealth = Mathf.Clamp(currentHealth,0,healthMax);
            if(currentHealth <= 0)
            {
                Destroy(gameObject);
            }
            OnHealthChange?.Invoke(this , EventArgs.Empty);
        }

        public float GetHealth()
        {
            return currentHealth;
        }

        public float HealthRatio()
        {
            return currentHealth/healthMax;
        }
    }
    
}
