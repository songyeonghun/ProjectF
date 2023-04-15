using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    bool playerGet = false;
    public Sprite open;

    public Transform spawnPoint;
    public GameObject itemPrefab;

    void Update()
    {
        if(Input.GetKeyDown("e") && Player.key > 0)
            if (playerGet == true)
            {
                //ÃÑ»ý¼º
                GameObject bullet = Instantiate(itemPrefab, spawnPoint.position, spawnPoint.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                Player.key--;
                this.gameObject.GetComponent<SpriteRenderer>().sprite = open;
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
