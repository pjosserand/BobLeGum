using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public CoinData coinsData;
    public int indexCoin;
    private SpriteRenderer spr;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        spr.sprite = coinsData.coins[indexCoin].cSprite;
        score = coinsData.coins[indexCoin].cScore;
    }

    public int GetScore()
    {
        return score;
    }
    
}
