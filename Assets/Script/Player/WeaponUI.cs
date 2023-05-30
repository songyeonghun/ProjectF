using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    public Sprite Pistol;
    public Sprite MachineGun;
    public Sprite Shutgun;

    void Update()
    {
        if ( Shooting.Weapon== 1)
        {
            gameObject.GetComponent<Image>().sprite = Pistol;
        }
        else if (Shooting.Weapon == 2)
        {
            gameObject.GetComponent<Image>().sprite = MachineGun;
        }
        else if (Shooting.Weapon == 3)
        {
            gameObject.GetComponent<Image>().sprite = Shutgun;
        }
    }
}
