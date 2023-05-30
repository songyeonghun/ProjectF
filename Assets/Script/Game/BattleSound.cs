using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSound : MonoBehaviour
{
    AudioSource a;
    public AudioClip b,c;

    void Start()
    {
        a = GetComponent<AudioSource>();
        a.clip = b;
        a.Play();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.tag == "Player")
            {
            a.clip = c;
            a.Play();
            }
    }
}
