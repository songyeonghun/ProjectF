using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBtn : MonoBehaviour
{
    public int weapon;
    public int money;

    public void click()
    {
        if (money <= Player.HaveCoin)
        {
            Player.HaveCoin -= money;
            Shooting.Weapon = weapon;
        }
    }
}
