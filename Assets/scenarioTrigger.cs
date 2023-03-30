using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scenarioTrigger : MonoBehaviour
{
    public GameObject TextUI;
    public TutorialManager tm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TextUI.SetActive(true);
        tm.TutorialText();
        Shooting.atkCool = true;
        Time.timeScale = 0;

        Destroy(gameObject);
    }
}
