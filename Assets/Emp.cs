using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emp : MonoBehaviour
{
    private void Start()
    {
        Invoke("flash", 0.3f);
        Debug.Log("����");
    }

    void flash()
    {
        Destroy(this.gameObject);
        Debug.Log("����");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
    }

}
