using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    
    public Sprite[] sprites = new Sprite[2];

    public BoxCollider2D boxCollider;
    public BoxCollider2D Trigger;

    SpriteRenderer spriteRenderer;
    Animator anim;

    

    public bool isClear = false;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (isClear == true) 
        {
            anim.SetBool("isOpen", true);
            spriteRenderer.sprite = sprites[0];
            boxCollider.enabled = false;

            Destroy(Trigger);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            anim.SetBool("isOpen", true);
            spriteRenderer.sprite = sprites[0];
            boxCollider.enabled = false;
        }

        if(collision.gameObject.tag=="collisionTilemap")
        {
            Debug.Log("ÆÄ±«");
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("isOpen", false);
            spriteRenderer.sprite = sprites[1];

            boxCollider.enabled = true;
        }
    }
}
