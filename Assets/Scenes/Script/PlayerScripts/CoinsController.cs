using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsController : MonoBehaviour
{
    public static CoinsController instance;
    private int coinsCnt;
    public TMP_Text coinsText;

    void Start()
    {
        instance = this;
        coinsCnt = 100;
        coinsText.text = coinsCnt.ToString();

    }

    // Update is called once per frame
    public void UpdateCoins(int num)
    {
        coinsCnt += num;
        coinsText.text = coinsCnt.ToString();
    }
}
