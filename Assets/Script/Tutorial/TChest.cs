using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TChest : MonoBehaviour
{
    bool playerGet = false;

    public Transform spawnPoint;
    public GameObject itemPrefab;

    void Update()
    {
        if (Input.GetKeyDown("e")&&Player.key>0)
            if (playerGet == true)
            {
                //ÃÑ°ú µ· »ý¼º
                GameObject bullet = Instantiate(itemPrefab, spawnPoint.position, spawnPoint.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                Player.key--;
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
