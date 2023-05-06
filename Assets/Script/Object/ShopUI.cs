using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    public void buyEmp()
    {
        if (Player.HaveCoin > 10)
        {
            Player.HaveCoin -= 10;
            Player.HaveEmp++;
        }
    }
    public void buyKey()
    {
        if (Player.HaveCoin > 10)
        {
            Player.HaveCoin -= 10;
            Player.HaveKey++;
        }   
    }
    public void buyRifle()
    {
        if (Player.HaveCoin > 50)
        {
            Player.HaveCoin -= 50;
            Shooting.Weapon = 3;
        }
    }
}
