using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{





    public void buyEmp()
    {
        if (Player.coin > 10)
        {
            Player.coin -= 10;
            Player.emp++;
        }
    }
    public void buyKey()
    {
        if (Player.coin > 10)
        {
            Player.coin -= 10;
            Player.key++;
        }
    }
    public void buyRifle()
    {
        if (Player.coin > 50)
        {
            Player.coin-=50;
            Shooting.Weapon = 3;
        }
    }



}
