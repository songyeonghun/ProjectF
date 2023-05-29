using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    bool playerGet = false;
    public Sprite open;
    AudioSource audio;

    public Transform spawnPoint;
    public GameObject itemPrefab;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    void Update()
    {
        if(Input.GetKeyDown("e") && Player.HaveKey > 0)
            if (playerGet == true)
            {
                //�ѻ���
                GameObject bullet = Instantiate(itemPrefab, spawnPoint.position, spawnPoint.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                Player.HaveKey--;
                this.gameObject.GetComponent<SpriteRenderer>().sprite = open;
                audio.Play();
                StartCoroutine(Open());
                playerGet = false;
            }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerGet = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerGet = false;
    }

    IEnumerator Open()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
