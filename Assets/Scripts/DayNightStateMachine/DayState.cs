using Scripts.Manager;
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
        private int coinCurrentPay;
        private float timer; //1f 1 coin
        private float coinToBuild;
        private float timeChangeState;
        private Controller.PosBuildingController currentPosBuilding;
        //public float Timer => timer;

        private bool IsTouchPosBuilding = false;
        private bool IsNightCallComplete = false;
        private bool IsActiveUILoad = false;

        public DayState(PlayerMovement player)
        {
            this.player = player;
        }
        public void Enter(DayNightController dayNightController)
        {
            //nd dau buoi sang
            OnChangeCurrentPosBuilding(player.currentPosBuilding);
            timeChangeState = 2.5f;
            player.OnChangeCurrentPosBuilding += OnChangeCurrentPosBuilding;
        }
        public void Excuted(DayNightController dayNightController)
        {
            IsTouchPosBuilding = currentPosBuilding != null;
            //sound call
            if (Input.GetKeyDown(KeyCode.Space) && !IsTouchPosBuilding)
            {
                Manager.SoundManager.Instance.PlaySound(Manager.SoundManager.Instance.ClipSO.NightCallStart);
                
            }
            //press space
            if (Input.GetKey(KeyCode.Space))
            {
                timer += Time.deltaTime * 1.3f;
                //Debug.Log(timer);           
                if (IsTouchPosBuilding && !currentPosBuilding.IsBuild)
                {
                    IsActiveUILoad = true;
                    if (player.costBuilding > 0 && (int)timer > coinCurrentPay)
                    {
                        coinCurrentPay++;
                        if (coinCurrentPay == 1)
                        {
                            Manager.SoundManager.Instance.PlaySound(Manager.SoundManager.Instance.ClipSO.StartPay);
                        }
                        else
                        {
                            Manager.SoundManager.Instance.PlaySound(Manager.SoundManager.Instance.ClipSO.ExcutedPay);
                        }
                        player.costBuilding--;
                        //Debug.Log(timer + " / " + coinToBuild);
                    }
                    else if (player.costBuilding == 0 && coinCurrentPay < coinToBuild)
                        return;
                    //Debug.Log(coinCurrentPay + " nguonfg mau tu" + coinToBuild);

                    if (coinCurrentPay >= coinToBuild )
                    {
                        BuildingConstruction building = BuildingConstruction.Create(currentPosBuilding.buildingType, currentPosBuilding.transform.position , currentPosBuilding);
                        Manager.ResourceManager.Instance.CalculateCost(currentPosBuilding.buildingType.money);
                        currentPosBuilding.setIsBuild();
                        coinCurrentPay = 0;
                        timer = 0f;
                        
                    }
                    LoadTimeUI.instance.UpdateTimer(timer, TimerRatioBuild() , IsTouchPosBuilding , currentPosBuilding.buildingType);
                }
                else if (!IsTouchPosBuilding)
                {
                    IsNightCallComplete = timer > timeChangeState;
                    LoadTimeUI.instance.UpdateTimer(timer, TimerRatioState(), IsTouchPosBuilding, null);    
                    if(IsNightCallComplete)
                    {
                        IsActiveUILoad = false;
                        LoadTimeUI.instance.setUILoad(IsActiveUILoad , IsNightCallComplete);
                        dayNightController.TranstitionToState(new NightState(player));
                        timer = 0f;
                        //Debug.Log("hahaha");
                    }
                }
                    
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                timer = 0f;
                IsActiveUILoad = false;
                if(!IsNightCallComplete)
                {
                    Manager.SoundManager.Instance.StopSound();
                }
                LoadTimeUI.instance.setUILoad(IsActiveUILoad, IsNightCallComplete);
                //Debug.Log("hohoho");
                if (coinCurrentPay > 0)
                    player.costBuilding += coinCurrentPay; //return
                    coinCurrentPay = 0;
            }
        }
        public void Exit(DayNightController dayNightController)
        {
            player.OnChangeCurrentPosBuilding -= OnChangeCurrentPosBuilding;
        }

        public void OnChangeCurrentPosBuilding(Controller.PosBuildingController currentPosBuilding)
        {
            timer = 0f;
            coinCurrentPay = 0;
            this.currentPosBuilding = currentPosBuilding;
            //cost
            if (currentPosBuilding != null)
            {
                coinToBuild = player.costBuilding;
            }
            else coinToBuild = 0f;
            
        }
        public float TimerRatioState()
        {
            return timer/timeChangeState;
        }
        public float TimerRatioBuild()
        {
            return timer / coinToBuild;
        }

    }

}
