using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace Scripts.DayNightStateMachine
{

    public class DayState : IDayNight
    {
        private PlayerMovement player;
        private float coinCurrentPay;
        private float timer; //1f 1 coin
        private float coinToBuild;
        private float timeChangeState;
        private PosBuildingController currentPosBuilding;
        private bool isBuild = false;
        public float Timer => timer;

        public DayState(PlayerMovement player)
        {
            this.player = player;
        }
        public void Enter(DayNightController dayNightController)
        {
            //nd dau buoi sang
            OnChangeCurrentPosBuilding(player.currentPosBuilding);
            timeChangeState = 5f;
            player.OnChangeCurrentPosBuilding += OnChangeCurrentPosBuilding;
        }
        public void Excuted(DayNightController dayNightController)
        {
            //logic thuc thi
            if (Input.GetKey(KeyCode.Space))
            {
                timer += Time.deltaTime;
                Debug.Log(timer);           
                LoadTimeUI.instance.UpdateTimer(timer, TimerRatio());
                if (currentPosBuilding != null)
                {
                    if (player.costBuilding > 0 && (int)timer > coinCurrentPay)
                    {
                        coinCurrentPay++;
                        
                        player.costBuilding--;
                    }
                    else if (player.costBuilding == 0 && coinCurrentPay < coinToBuild)
                        return;
                    Debug.Log(coinCurrentPay + " nguonfg mau tu" + coinToBuild);

                    if (coinCurrentPay == coinToBuild )
                    {
                        //Build
                        //currentPosBuilding.Build();
                        Debug.Log("halo");
                        BuildingConstruction building = BuildingConstruction.Create(currentPosBuilding.buildingType, currentPosBuilding.transform.position , currentPosBuilding);
                        coinCurrentPay = 0f;
                        timer = 0f;
                        
                    }
                }
                else if (timer >= timeChangeState)
                    dayNightController.TranstitionToState(new NightState(player));

            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                timer = 0f;
                if (coinCurrentPay > 0)
                    player.costBuilding += coinCurrentPay; //return
                    coinCurrentPay = 0;
            }
        }
        public void Exit(DayNightController dayNightController)
        {
            player.OnChangeCurrentPosBuilding -= OnChangeCurrentPosBuilding;
        }

        public void OnChangeCurrentPosBuilding(PosBuildingController currentPosBuilding)
        {
            timer = 0f;
            coinCurrentPay = 0f;
            this.currentPosBuilding = currentPosBuilding;
            //cost
            if (currentPosBuilding != null)
            {
                coinToBuild = player.costBuilding;
            }
            else coinToBuild = 0f;
            
        }
        public float TimerRatio()
        {
            return timer/timeChangeState;
        }

    }

}
