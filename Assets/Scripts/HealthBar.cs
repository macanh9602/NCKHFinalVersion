using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

    public class HealthBar : MonoBehaviour
    {
        [SerializeField] HealthSysterm healthSysterm;

        private void Start()
        {
            healthSysterm.OnHealthChange += HealthSysterm_OnHealthChange;
        }

        private void HealthSysterm_OnHealthChange(object sender, System.EventArgs e)
        {
            UpdateBar();
        }

        public void UpdateBar()
        {
            transform.Find("Bar").localScale = new Vector3(healthSysterm.HealthRatio(), 1, 1);
        }
    }

