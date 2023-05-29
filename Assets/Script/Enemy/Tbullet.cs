using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tbullet : MonoBehaviour
{
    public int TowerNum;


    private void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(gameObject.transform.right*1, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            if (TowerNum == 1)
                collision.transform.position = new Vector2(-55.5f,3.5f);
            else if (TowerNum == 2)
                collision.transform.position = new Vector2(-55.5f,35.5f);

        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
