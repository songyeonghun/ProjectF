using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatePoint : MonoBehaviour
{
    public Image Off;
    public Sprite On;

    void StateUp()
    {
        Off.sprite = On;
    }

}
