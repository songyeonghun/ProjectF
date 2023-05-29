using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    int BatteryCode;
    SpriteRenderer battery;

    public Sprite Mangan;
    public Sprite Alkaline;
    public Sprite Lithium;

    private void Start()
    {
        this.BatteryCode = Random.Range(0, 3);
        battery = GetComponent<SpriteRenderer>();
        if (BatteryCode == 0)
        {
            battery.sprite = Mangan;
        }
        else if (BatteryCode == 1)
        {
            battery.sprite = Alkaline;
        }
        else if (BatteryCode == 2)
        {
            battery.sprite = Lithium;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.CurrentHp += (BatteryCode+1) * 50;
            if (Player.CurrentHp > Player.MaxHp)
            {
                Player.CurrentHp = Player.MaxHp;
            }
            Destroy(gameObject);
        }
    }
}
