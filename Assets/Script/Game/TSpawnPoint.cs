using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TSpawnPoint : MonoBehaviour
{
    GameObject player;

    private void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player");
        player.transform.position = gameObject.transform.position;
    }


}
