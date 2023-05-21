using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject Player;
    private void Start()
    {
        Instantiate(Player, gameObject.transform.position, Quaternion.identity);
    }
}
