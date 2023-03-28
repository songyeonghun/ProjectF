using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    bool playerGet = false;



    void Update()
    {
        if(Input.GetKeyDown(""))
            if (playerGet == true)
            {
                //ÃÑ°ú µ· »ý¼º
                Destroy(gameObject);
            }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerGet = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerGet = false;
    }
}
