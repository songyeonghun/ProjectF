using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackWall : MonoBehaviour
{
    int crackCount = 0;
    public GameObject Sound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            crackCount += 1;
            if (crackCount >= 3)
            {
                Instantiate(Sound, this.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }



}
