//using AntiStress.MiniGame.BreakingBall;
//using AntiStress.MiniGame.ChristmasTree;
//using AntiStress.MiniGame.FidgetSpinner;
//using AntiStress.MiniGame.PopIt.PopIt1;
using Sirenix.OdinInspector;
using UnityEngine;
using System;
using System.Collections.Generic;
using AntiStress;
using System.Linq;
using System.Globalization;
/*using AntiStress.MiniGame.MoneyGun;
using AntiStress.MiniGame.PressSand;
using AntiStress.MiniGame.Slime3;*/

namespace VTLTools
{
    public class StaticVariables
    {
        #region Public Variables
        [ShowInInspector, BoxGroup("Setting")]
        public static bool IsSoundOn
        {
            get => userData.isSoundOn;
            set
            {
                userData.isSoundOn = value;
                SaveData();
            }
        }

        [ShowInInspector, BoxGroup("Setting")]
        public static bool IsMusicOn
        {
            get => userData.isMusicOn;
            set
            {
                userData.isMusicOn = value;
                SaveData();
            }
        }

        [ShowInInspector, BoxGroup("Setting")]
        public static bool IsVibrationOn
        {
            get => userData.isVibrationOn;
            set
            {
                userData.isVibrationOn = value;
                SaveData();
            }
        }

        [ShowInInspector, BoxGroup("Data")]
        public static int CountGamePlayed
        {
            get => userData.countGamePlayed;
            set
            {
                userData.countGamePlayed = value;
                SaveData();
            }
        }

       // [ShowInInspector, BoxGroup("Data")]
       /* public static List<PopItUnlockProgress> PopItProgress
        {
            get => userData.popItUnlockProgressList;
        }
        public static void UnlockPopIt(PopItFidgetId _id)
        {
            userData.popItUnlockProgressList.Add(new PopItUnlockProgress()
            {
                id = _id,
            });
            SaveData();
        }

        [ShowInInspector, BoxGroup("Data")]
        public static PopItFidgetId CurrentPopItFidgetId
        {
            get => userData.currentPopItFidgetId;
            set
            {
                userData.currentPopItFidgetId = value;
                SaveData();
            }
        }

        [ShowInInspector, BoxGroup("Data")]
        public static PopItFidgetId CurrentPopIt3FidgetId
        {
            get => userData.currentPopIt3FidgetId;
            set
            {
                userData.currentPopIt3FidgetId = value;
                SaveData();
            }
        }
       */
        //[ShowInInspector, BoxGroup("Data")]
        //public static List<JigsawUnlockProgress> JigsawProgress
        //{
        //    get
        //    {
        //        return userData.jigsawUnlockProgressList;
        //    }
        //}
        
        //public static void UnlockJigsaw(JigsawId _id)
        //{
        //    userData.jigsawUnlockProgressList.Add(new JigsawUnlockProgress()
        //    {
        //        id = _id,
        //    });
        //    SaveData();
        //}
        /*
        [ShowInInspector, BoxGroup("Data")]
        public static List<WoodCanUnlockProgress> WoodCanProgress
        {
            get => userData.woodCanUnlockProgressList;
        }
        public static void UnlockWoodCan(WoodCanId _id)
        {
            userData.woodCanUnlockProgressList.Add(new WoodCanUnlockProgress()
            {
                id = _id,
            });
            SaveData();
        }

        [ShowInInspector, BoxGroup("Data")]
        public static WoodCanId CurrentWoodCanId
        {
            get => userData.currentWoodCanId;
            set
            {
                userData.currentWoodCanId = value;
                SaveData();
            }
        }

        [ShowInInspector, BoxGroup("Data")]
        public static List<PlasticBallUnlockProgress> PlasticBallProgress
        {
            get => userData.plasticBallUnlockProgressList;
        }
        public static void UnlockPlasticBall(PlasticBallId _id)
        {
            userData.plasticBallUnlockProgressList.Add(new PlasticBallUnlockProgress()
            {
                id = _id,
            });
            SaveData();
        }

        [ShowInInspector, BoxGroup("Data")]
        public static PlasticBallId CurrentPlasticBallId
        {
            get => userData.currentPlasticBallId;
            set
            {
                userData.currentPlasticBallId = value;
                SaveData();
            }
        }

        [ShowInInspector, BoxGroup("Data")]
        public static List<SpinnerUnlockProgress> SpinnerProgress
        {
            get => userData.spinnerUnlockProgressList;
        }
        public static void UnlockSpinner(FidgetSpinnerId _id)
        {
            userData.spinnerUnlockProgressList.Add(new SpinnerUnlockProgress()
            {
                id = _id,
            });
            SaveData();
        }

        [ShowInInspector, BoxGroup("Data")]
        public static FidgetSpinnerId CurrentSpinnerId
        {
            get => userData.currentSpinnerId;
            set
            {
                userData.currentSpinnerId = value;
                SaveData();
            }
        }*/

       // [ShowInInspector, BoxGroup("Cheat")]
        public static bool IsCheatNoAd
        {
            get => userData.isCheatNoAds;
            set
            {
                userData.isCheatNoAds = value;
                SaveData();
            }
        }

        [ShowInInspector, BoxGroup("Cheat")]
        public static bool IsShowFps
        {
            get => userData.isShowFps;
            set
            {
                userData.isShowFps = value;
                SaveData();
            }
        }

        [ShowInInspector, BoxGroup("Cheat")]
        public static bool IsShowDebug
        {
            get => userData.isShowDebug;
            set
            {
                userData.isShowDebug = value;
                SaveData();
            }
        }

        [ShowInInspector, BoxGroup("Cheat")]
        public static bool IsShowMaxMediationDebug
        {
            get => userData.isShowMediationDebug;
            set
            {
                userData.isShowMediationDebug = value;
                SaveData();
            }
        }

        [ShowInInspector, BoxGroup("PushRate")]
        public static bool IsRated
        {
            get => userData.isRated;
            set
            {
                userData.isRated = value;
                SaveData();
            }
        }

        [ShowInInspector, BoxGroup("PushRate")]
        public static bool IsShowRateAtLeastOne
        {
            get => userData.isShowRateAtLeastOne;
            set
            {
                userData.isShowRateAtLeastOne = value;
                SaveData();
            }
        }

        [ShowInInspector, BoxGroup("PushRate")]
        public static int CurrentIndexShowRate
        {
            get => userData.currentIndexShowRate;
            set
            {
                userData.currentIndexShowRate = value;
                SaveData();
            }
        }

        [ShowInInspector, BoxGroup("Ads")]
        public static bool IsRemovedAds
        {
            get => userData.isRemovedAds;
            set
            {
                userData.isRemovedAds = value;
                SaveData();
            }
        }

        [ShowInInspector, BoxGroup("Ads")]
        public static bool IsRalaxPackPaid
        {
            get => userData.isRelaxPackPaid;
            set
            {
                userData.isRelaxPackPaid = value;
                SaveData();
            }
        }

        [ShowInInspector, BoxGroup("Static")]
        public static bool isCheckedUpdate;

        [ShowInInspector, BoxGroup("Tutorial")]
        public static bool IsGyroscopeTutorialShowed
        {
            get => userData.isGyroscopeTutorialShowed;
            set
            {
                userData.isGyroscopeTutorialShowed = value;
                SaveData();
            }
        }

        [ShowInInspector, BoxGroup("Tutorial")]
        public static bool IsFifteenGameTutorialShowed
        {
            get => userData.isFifteenGameTutorialShowed;
            set
            {
                userData.isFifteenGameTutorialShowed = value;
                SaveData();
            }
        }

        [ShowInInspector, BoxGroup("Tutorial")]
        public static bool IsHanoiTowerTutorialShowed
        {
            get => userData.isHanoiTowerTutorialShowed;
            set
            {
                userData.isHanoiTowerTutorialShowed = value;
                SaveData();
            }
        }

       /* [ShowInInspector, BoxGroup("Data")]
        public static List<DecorUnlockProgress> DecorUnlockProgress
        {
            get
            {
                return userData.decorUnlockProgressList;
            }
        }*/

       /* public static void UnlockDecor(DecorId _id)
        {
            userData.decorUnlockProgressList.Add(new DecorUnlockProgress()
            {
                id = _id,
            });
            SaveData();
        }*/

        //[ShowInInspector, BoxGroup("Data")]
        //public static List<MiniGameId> FavoriteMiniGames
        //{
        //    get
        //    {
        //        return userData.favoriteMiniGameList;
        //    }
        //}

        //public static void AddGameToFavorite(MiniGameId _id)
        //{
        //    userData.favoriteMiniGameList.Add(_id);
        //    SaveData();
        //}

        //public static void RemoveGameFromFavorite(MiniGameId _id)
        //{
        //    userData.favoriteMiniGameList.Remove(_id);
        //    SaveData();
        //}

        //public static bool IsFavoriteGame(MiniGameId _id)
        //{
        //    return userData.favoriteMiniGameList.Contains(_id);
        //}

        //[ShowInInspector, BoxGroup("Data")]
        //public static List<PremiumGameUnlockProgress> PremiumGameUnlockProgressList
        //{
        //    get
        //    {
        //        return userData.premiumGameUnlockProgressList;
        //    }
        //}

        //public static void UnlockPremiumMiniGame(MiniGameId _id)
        //{
        //    userData.premiumGameUnlockProgressList.Add(new PremiumGameUnlockProgress()
        //    {
        //        id = _id,
        //    });
        //    SaveData();
        //}

        //public static bool IsPremiumGameUnlocked(MiniGameId _id)
        //{
        //    return userData.premiumGameUnlockProgressList.Any(x => x.id == _id);
        //}

        public static int UnlockedPremiumGameCount
        {
            get
            {
                return userData.unlockedPremiumGameCount;
            }
            set
            {
                userData.unlockedPremiumGameCount = value;
                SaveData();
            }
        }

        public static int CountPurchasePremiumFail
        {
            get
            {
                return userData.countPurchasePremiumFail;
            }
            set
            {
                userData.countPurchasePremiumFail = value;
                SaveData();
            }
        }

        public static bool IsSaleTime
        {
            get
            {
                return userData.isSaleTime;
            }
            set
            {
                userData.isSaleTime = value;
                SaveData();
            }
        }

        public static DateTime EndTimeSale
        {
            get
            {
                return DateTime.Parse(userData.endSaleTime, CultureInfo.InvariantCulture);
            }
            set
            {
                userData.endSaleTime = value.ToString(CultureInfo.InvariantCulture);
                SaveData();
            }
        }

      /*  [ShowInInspector, BoxGroup("Data")]
        public static List<MoneyUnlockProgress> MoneyUnlockProgressList
        {
            get => userData.moneyUnlockProgressList;
        }
        public static void UnlockMoney(MoneyId _id)
        {
            userData.moneyUnlockProgressList.Add(new MoneyUnlockProgress()
            {
                id = _id,
            });
            SaveData();
        }


        public static MoneyId CurrentMoneyId
        {
            get => userData.currentMoneyId;
            set
            {
                userData.currentMoneyId = value;
                SaveData();
            }
        }

        public static List<SandShapeUnlockProgress> SandShapeUnlockProgressList
        {
            get => userData.sandShapeUnlockProgressList;
        }
        public static void UnlockSandShape(SandShapeID _id)
        {
            userData.sandShapeUnlockProgressList.Add(new SandShapeUnlockProgress()
            {
                id = _id,
            });
            SaveData();
        }


        public static SandShapeID CurrentSandShapeId
        {
            get => userData.currentSandShapeId;
            set
            {
                userData.currentSandShapeId = value;
                SaveData();
            }
        }

        public static List<SlimeUnlockProgress> SlimeUnlockProgressList
        {
            get => userData.slimeUnlockProgressList;
        }
        public static void UnlockSlime(SlimeId _id)
        {
            userData.slimeUnlockProgressList.Add(new SlimeUnlockProgress()
            {
                id = _id,
            });
            SaveData();
        }


        public static SlimeId CurrentSlimeId
        {
            get => userData.currentSlimeId;
            set
            {
                userData.currentSlimeId = value;
                SaveData();
            }
        }

        public static List<ToppingUnlockProgress> ToppingUnlockProgressList
        {
            get => userData.toppingUnlockProgressList;
        }
        public static void UnlockTopping(ToppingId _id)
        {
            userData.toppingUnlockProgressList.Add(new ToppingUnlockProgress()
            {
                id = _id,
            });
            SaveData();
        }


        public static ToppingId CurrentToppingId
        {
            get => userData.currentToppingId;
            set
            {
                userData.currentToppingId = value;
                SaveData();
            }
        }*/

        public static bool IsShowSnakeAndLadderTutorial
        {
            get => userData.isShowSnakeAndLadderTutorial;
            set
            {
                userData.isShowSnakeAndLadderTutorial = value;
                SaveData();
            }
        }
        #endregion

        #region User Data
        static UserData userData;

        [ShowInInspector]
        static StaticVariables()
        {
            userData = GetData();
            if (userData == null)
            {
                userData = new UserData();
                SaveData();
            }
        }

        static void SaveData()
        {
            VTLPlayerPrefs.SetObjectValue(StringsSafeAccess.PREF_USER_DATA, userData);
        }
        static UserData GetData()
        {
            return VTLPlayerPrefs.GetObjectValue<UserData>(StringsSafeAccess.PREF_USER_DATA);
        }
        #endregion*/
    }

    [Serializable]
    public class UserData
    {
        public bool isSoundOn;
        public bool isMusicOn;
        public bool isVibrationOn;
        public string currentLanguage;

        public int countGamePlayed;

        public bool isCheatNoAds;
        public bool isShowFps;
        public bool isShowDebug;
        public bool isShowMediationDebug;

        public bool isRemovedAds;

        public bool isRated;
        public bool isShowRateAtLeastOne;
        public int currentIndexShowRate;

      //  public List<PopItUnlockProgress> popItUnlockProgressList;
       // public PopItFidgetId currentPopItFidgetId;
      //  public PopItFidgetId currentPopIt3FidgetId;
        //public List<JigsawUnlockProgress> jigsawUnlockProgressList;
      //  public List<WoodCanUnlockProgress> woodCanUnlockProgressList;
     //   public WoodCanId currentWoodCanId;
      //  public List<PlasticBallUnlockProgress> plasticBallUnlockProgressList;
     //   public PlasticBallId currentPlasticBallId;
      //  public List<SpinnerUnlockProgress> spinnerUnlockProgressList;
     //   public FidgetSpinnerId currentSpinnerId;

        public bool isGyroscopeTutorialShowed;
        public bool isFifteenGameTutorialShowed;
        public bool isHanoiTowerTutorialShowed;

      //  public List<DecorUnlockProgress> decorUnlockProgressList;
        //public List<MiniGameId> favoriteMiniGameList;
        //public List<PremiumGameUnlockProgress> premiumGameUnlockProgressList;
        public int unlockedPremiumGameCount;
        public bool isRelaxPackPaid;
        public int countPurchasePremiumFail;

        public bool isSaleTime;

        public string endSaleTime;

        /*public List<MoneyUnlockProgress> moneyUnlockProgressList;
        public MoneyId currentMoneyId;

        public List<SandShapeUnlockProgress> sandShapeUnlockProgressList;
        public SandShapeID currentSandShapeId;

        public List<SlimeUnlockProgress> slimeUnlockProgressList;
        public SlimeId currentSlimeId;

        public List<ToppingUnlockProgress> toppingUnlockProgressList;
       public ToppingId currentToppingId;
*/
        public bool isShowSnakeAndLadderTutorial;

        public UserData()
        {
            isSoundOn = true;
            isMusicOn = true;
            isVibrationOn = true;
            //currentLanguage = LocalizationManager.CurrentLanguage;

            countGamePlayed = 0;

            isCheatNoAds = false;
            isShowFps = false;
            isShowDebug = false;
            isShowMediationDebug = false;

            isRated = false;
            isShowRateAtLeastOne = false;
            currentIndexShowRate = 0;

            isRemovedAds = false;

            //popItUnlockProgressList = new()
            //            {
            //                new()
            //                {
            //                    id = PopItFidgetId.toyRound
            //                }
            //            };
            //currentPopItFidgetId = PopItFidgetId.toyRound;
            //currentPopIt3FidgetId = PopItFidgetId.toyUnicon;
            //woodCanUnlockProgressList = new()
            //            {
            //                new()
            //                {
            //                    id = WoodCanId.LightClassicCan
            //                }
            //            };
            //currentWoodCanId = WoodCanId.LightClassicCan;
            //plasticBallUnlockProgressList = new()
            //            {
            //                new()
            //                {
            //                   // id = PlasticBallId.Ball1
            //                }
            //            };
            //currentPlasticBallId = PlasticBallId.Ball1;
            //spinnerUnlockProgressList = new()
            //            {
            //                new()
            //                {
            //                   // id = FidgetSpinnerId.Spinner01
            //                }
            //            };
            //currentSpinnerId = FidgetSpinnerId.Spinner01;

            isGyroscopeTutorialShowed = false;
            isFifteenGameTutorialShowed = false;
            isHanoiTowerTutorialShowed = false;

           // decorUnlockProgressList = new();

            //favoriteMiniGameList = new();
            //premiumGameUnlockProgressList = new();
            unlockedPremiumGameCount = 0;
            isRelaxPackPaid = false;
            countPurchasePremiumFail = 0;
            isSaleTime = false;
            endSaleTime = DateTime.MinValue.ToString(CultureInfo.InvariantCulture);

            /*moneyUnlockProgressList = new();
            currentMoneyId = MoneyId.US;

            sandShapeUnlockProgressList = new();
            currentSandShapeId = SandShapeID.Shape1;

            slimeUnlockProgressList = new();
            currentSlimeId = SlimeId.RainbowSmooth;

            toppingUnlockProgressList = new();
            currentToppingId = ToppingId.Cubes;*/

            isShowSnakeAndLadderTutorial = false;
        }

        public override string ToString()
        {
            return $"UserData: \n" +
                   $"isSoundOn: {isSoundOn}\n" +
                   $"isMusicOn: {isMusicOn}\n" +
                   $"isVibrationOn: {isVibrationOn}\n" +
                   $"currentLanguage: {currentLanguage}\n" +
                   $"countGamePlayed: {countGamePlayed}\n" +
                   $"isCheatNoAds: {isCheatNoAds}\n" +
                   $"isShowFps: {isShowFps}\n" +
                   $"isShowDebug: {isShowDebug}\n" +
                   $"isShowMediationDebug: {isShowMediationDebug}\n" +
                   $"isRemovedAds: {isRemovedAds}\n" +
                   $"isRated: {isRated}\n" +
                   $"isShowRateAtLeastOne: {isShowRateAtLeastOne}\n" +
                   $"currentIndexShowRate: {currentIndexShowRate}\n" 
                  /* $"popItUnlockProgressList: {string.Join(", ", popItUnlockProgressList)}\n" +
                   $"currentPopItFidgetId: {currentPopItFidgetId}\n" +
                   $"jigsawUnlockProgressList: {string.Join(", ", jigsawUnlockProgressList)}\n" +
                   $"woodCanUnlockProgressList: {string.Join(", ", woodCanUnlockProgressList)}\n" +
                   $"currentWoodCanId: {currentWoodCanId}\n" +
                   $"plasticBallUnlockProgressList: {string.Join(", ", plasticBallUnlockProgressList)}\n" +
                 $"currentPlasticBallId: {currentPlasticBallId}\n" +
                   $"spinnerUnlockProgressList: {string.Join(", ", spinnerUnlockProgressList)}\n" +
                   $"currentSpinnerId: {currentSpinnerId}\n" +
                   $"isGyroscopeTutorialShowed: {isGyroscopeTutorialShowed}\n" +
                   $"isFifteenGameTutorialShowed: {isFifteenGameTutorialShowed}\n" +
                   $"isHanoiTowerTutorialShowed: {isHanoiTowerTutorialShowed}\n" +
                   $"decorUnlockProgressList: {string.Join(", ", decorUnlockProgressList)}"*/;
                  
        }
    }

/*    [Serializable]
    public class PopItUnlockProgress
    {
        public PopItFidgetId id;
        public override string ToString()
        {
            return id.ToString();
        }
    }*/

    //[Serializable]
    //public class JigsawUnlockProgress
    //{
    //    public JigsawId id;
    //    public override string ToString()
    //    {
    //        return id.ToString();
    //    }
    //}

/*    [Serializable]
    public class WoodCanUnlockProgress
    {
        public WoodCanId id;
        public override string ToString()
        {
            return id.ToString();
        }
    }*/

 /*   [Serializable]
    public class PlasticBallUnlockProgress
    {
        public PlasticBallId id;
        public override string ToString()
        {
            return id.ToString();
        }
    }*/

 /*   [Serializable]
    public class SpinnerUnlockProgress
    {
        public FidgetSpinnerId id;
        public override string ToString()
        {
            return id.ToString();
        }
    }*/

  /*  [Serializable]
    public class DecorUnlockProgress
    {
        public DecorId id;
        public override string ToString()
        {
            return id.ToString();
        }
    }*/

    //[Serializable]
    //public class PremiumGameUnlockProgress
    //{
    //    public MiniGameId id;
    //    public override string ToString()
    //    {
    //        return id.ToString();
    //    }
    //}

 /*   [Serializable]
    public class MoneyUnlockProgress
    {
        public MoneyId id;
        public override string ToString()
        {
            return id.ToString();
        }
    }*/

   /*[Serializable]
    public class SandShapeUnlockProgress
    {
        public SandShapeID id;
        public override string ToString()
        {
            return id.ToString();
        }
    }

    [Serializable]
    public class SlimeUnlockProgress
    {
        public SlimeId id;
        public override string ToString()
        {
            return id.ToString();
        }
    }

    [Serializable]
    public class ToppingUnlockProgress
    {
        public ToppingId id;
        public override string ToString()
        {
            return id.ToString();
        }
    }*/
}