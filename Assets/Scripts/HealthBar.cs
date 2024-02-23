using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Scripts{
    
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] HealthSysterm healthSysterm;
        private Transform BG;
        private Transform Bar;
        private void Start()
        {
            healthSysterm.OnHealthChange += HealthSysterm_OnHealthChange;
            BG = transform.Find("BG");
            Bar = transform.Find("Bar");
            BG.GetComponent<SpriteRenderer>().DOFade(0f, 1f);
            Bar.GetComponent<SpriteRenderer>().DOFade(0f, 1f);
        }

        private void HealthSysterm_OnHealthChange(object sender, System.EventArgs e)
        {
            Show();
            UpdateBar();
        }

        public void UpdateBar()
        {
            transform.Find("Bar").localScale = new Vector3(healthSysterm.HealthRatio() , 1 ,1);
        }

        private void Hide()
        {
            BG.GetComponent<SpriteRenderer>().DOFade(0f, 2f).SetEase(Ease.InElastic);
            Bar.GetComponent<SpriteRenderer>().DOFade(0f, 2f).SetEase(Ease.InElastic);

        }
        private void Show()
        {
            BG.GetComponent<SpriteRenderer>().DOFade(1, 1f).SetEase(Ease.InElastic);
            Bar.GetComponent<SpriteRenderer>().DOFade(1f, 1f).SetEase(Ease.InElastic);
        }
    }
    
}
