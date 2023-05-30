using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSet : MonoBehaviour
{
    int pickUpCode;

    SpriteRenderer PickUp;

    public Sprite Key;
    public Sprite Emp;

    private void Start()
    {
        pickUpCode = Random.Range(0, 2);
        PickUp = GetComponent<SpriteRenderer>();
        if (pickUpCode == 0)
        {
            PickUp.sprite = Key;
        }
        else if (pickUpCode == 1)
        {
            PickUp.sprite = Emp;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (pickUpCode)
            {
                case 0:
                    Player.HaveKey += 5;
                    break;
                case 1:
                    Player.HaveEmp += 5;
                    break;
            }
            Destroy(gameObject);
        }
    }
}
