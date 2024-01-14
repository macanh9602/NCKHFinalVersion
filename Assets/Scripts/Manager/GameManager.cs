using Scripts.DayNightStateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Manager{
    
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance {  get; private set; }
        //can biet so quai da diet (lay tu EnemyManager)
        //so quai turn do ( mac dinh = 10)
        //logic so quai da diet = sp quai turn do thi goi buoi dem
        [SerializeField] int enemiesMaxAmount = 10;
        [SerializeField] int enemiesDieAmount;

        private void Start()
        {
            instance = this;
        }
        //co ham logic reset chi so sau moi buoi dem (ham end night se goi de xu ly)
        private void Update()
        {

        }

        public void ResetAfterNight()
        {
            
        }

        //public void LogicTransitionToDay()
        //{
        //    enemiesDieAmount = Manager.EnemyManager.Instance.EnemiesDieAmount;
        //    //Debug.Log(enemiesDieAmount);
        //    if (enemiesDieAmount >= enemiesMaxAmount)
        //    {
        //        //transtition to day
        //        dayNightController.TranstitionToState(new DayState(player));
        //        //reset
        //    }
        //}

    }
    
}
