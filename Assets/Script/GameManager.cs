using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public int StatCoin=0;

    private void Start()
    {
        PlayerPrefs.SetInt("StatCoin", StatCoin);
    }


}
