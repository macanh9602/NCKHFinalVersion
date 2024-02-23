using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{

    [CreateAssetMenu(menuName = "SO/BuildingTypeSO")]
    public class BuildingTypeSO : ScriptableObject
    {
        public string nameBuilding;
        public Transform prefabs;
        public float timeBuild;
        public int money;
        public Sprite sprite;
        public Sprite icon;
        public string details;
        public Damaging CanDamaging;
        public Receivable CanReceivable;
        public Hall isTownHall;
    }

    [System.Serializable]
    public class Damaging
    {
        public float damage;
        public float amor;
        public string typeOfWeapon;
    }

    [System.Serializable]
    public class Receivable
    {
        public float moneyReceivable;
    }

    [System.Serializable]
    public class Hall
    {
        public int addSlot;
    }




}
