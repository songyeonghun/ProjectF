using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    public Transform[] spawnPoint;
    public GameObject Monster;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            GameObject bullet = Instantiate(Monster, spawnPoint[0].position, spawnPoint[0].rotation);
            GameObject bullet1 = Instantiate(Monster, spawnPoint[1].position, spawnPoint[1].rotation);
            GameObject bullet2 = Instantiate(Monster, spawnPoint[2].position, spawnPoint[2].rotation);
            GameObject bullet3 = Instantiate(Monster, spawnPoint[3].position, spawnPoint[3].rotation);
        }
    }
}
