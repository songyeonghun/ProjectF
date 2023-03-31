using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TMonsterSpawn : MonoBehaviour
{
    public Transform Spawn;
    public GameObject Monster;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(Monster, Spawn.position, Spawn.rotation);
    }


}
