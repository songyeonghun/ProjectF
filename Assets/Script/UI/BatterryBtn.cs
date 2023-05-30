using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatterryBtn : MonoBehaviour
{
    public int Hp=0;
    public int money=0;
public void click()
    {
        if (money <= Player.HaveCoin)
        {
            Player.HaveCoin -= money;
            Player.CurrentHp += Hp;
            if (Player.CurrentHp > Player.MaxHp)
            {
                Player.CurrentHp = Player.MaxHp;
            }
        }

    }
}
