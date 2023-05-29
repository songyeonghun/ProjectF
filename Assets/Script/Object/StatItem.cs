using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatItem : MonoBehaviour
{
    int itemCode;
    SpriteRenderer item;

    public Sprite Series;
    public Sprite Parallel;
    public Sprite Solenoid;
    public Sprite Transistor;

    private void Start()
    {
        this.itemCode = Random.Range(0, 4);
        item = GetComponent<SpriteRenderer>();
        if (itemCode == 0)
        {
            item.sprite = Series;
        }
        else if (itemCode == 1)
        {
            item.sprite = Parallel;
        }
        else if (itemCode == 2)
        {
            item.sprite = Solenoid;
        }
        else if (itemCode == 3)
        {
            item.sprite = Transistor;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (itemCode)
            {
                case 0:
                    Player.MaxHp -= 30;
                    Player.CurrentHp -= 30;
                    Bullet.itemDamage += 3;
                    break;
                case 1:
                    Player.MaxHp += 50;
                    Player.CurrentHp += 50;
                    Bullet.itemDamage -= 2;
                    break;
                case 2:
                    Player.MaxHp += 100;
                    Player.CurrentHp += 100;
                    break;
                case 3:
                    Bullet.itemDamage += 5;
                    break;

            }
            
            Destroy(gameObject);
        }
    }
}
