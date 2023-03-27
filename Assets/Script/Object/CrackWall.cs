using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackWall : MonoBehaviour
{
    int crackCount = 0;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            crackCount += 1;
            if (crackCount >= 3)
            {
                Destroy(gameObject);
            }
        }
    }



}
