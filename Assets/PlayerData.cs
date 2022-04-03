using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int[] coinsFound;
    public int[] coinsMax;

    public PlayerData(int[] coinsFound, int[] coins)
    {
        this.coinsFound = coinsFound;
        this.coinsMax = coins;
    }
}
