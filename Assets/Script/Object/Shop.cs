using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject ShopUi;
    bool Player = false;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && Player == true)
        {
            ShopUi.SetActive(true);
            Shooting.atkCool = true;
            Time.timeScale = 0;

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player = false;
        }
    }



}
