using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts{
    
    public class HealthSysterm : MonoBehaviour
    {
        [SerializeField] float healthMax;
        [SerializeField] float currentHealth;

        private void Start()
        {
            currentHealth = healthMax;
        }
        public void OnDamage(float damage)
        {
            currentHealth -= damage;
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
