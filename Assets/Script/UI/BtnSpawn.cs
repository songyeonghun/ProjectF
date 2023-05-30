using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSpawn : MonoBehaviour
{
    public GameObject[] item;

    private void Start()
    {
        item[Random.Range(0,12)].SetActive(true);
    }
}
