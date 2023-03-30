using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
   static public int WeaponCode;

    private void Start()
    {
        WeaponCode = Random.Range(1, 3);
        Debug.Log(WeaponCode);
    }

}
