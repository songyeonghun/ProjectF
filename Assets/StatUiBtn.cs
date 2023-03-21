using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatUiBtn : MonoBehaviour
{
    public GameObject StateUi;
    public void delete()
    {
        PlayerPrefs.DeleteAll();
    }

    public void Close()
    {
        StateUi.SetActive(false);
        Time.timeScale = 1;
        Shooting.atkCool = false;
    }
}
