using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSetBtn : MonoBehaviour
{
    public int Item;
    public int money;

    public void click()
    {
        if (money <= Player.HaveCoin)
        {
            Player.HaveCoin -= money;
            if (Item == 0)
            {
                Player.HaveEmp += 5;
            }
            else
            {
                Player.HaveKey += 5;
            }
        }
    }
}
