using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatItemBtn : MonoBehaviour
{
    public int Item;
    public int money;

    public void click()
    {
        if (money <= Player.HaveCoin)
        {
            Player.HaveCoin -= money;
            switch (Item)
            {
                case 0:
                    Player.MaxHp -= 30;
                    Player.CurrentHp -= 30;
                    Bullet.itemDamage += 3;
                    break;
                case 1:
                    Player.MaxHp += 50;
                    Player.CurrentHp += 50;
                    Bullet.itemDamage -= 2;
                    break;
                case 2:
                    Player.MaxHp += 100;
                    Player.CurrentHp += 100;
                    break;
                case 3:
                    Bullet.itemDamage += 5;
                    break;
            }
        }
    }
}
