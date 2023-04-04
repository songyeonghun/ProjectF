using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    static public int StatCoin;

    private void Start()
    {
        PlayerPrefs.SetInt("StatCoin", StatCoin);
    }


}
