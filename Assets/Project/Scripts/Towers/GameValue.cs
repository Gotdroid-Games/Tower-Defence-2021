using System;
using UnityEngine;

public class GameValue : MonoBehaviour
{
    [System.Serializable]
    public class QuaityData
    {
        public float _newfirecontdown = 1f;
        public int _towerPrice;
        public int _rangedTowerDamage;
        public int _rangeTowerCritDamage;
        public int _towerRangeUpgrade;
    }
}
