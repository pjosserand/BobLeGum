using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CoinData", menuName = "ScriptableObjects/CoinData", order = 1)]

public class CoinData : ScriptableObject
{
    public List<Coin> coins;
    [System.Serializable]
    public class Coin
    {
        public string cName;
        public Sprite cSprite;
        public int cScore;
    }
}
