using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Slider hpbar;
    public float maxHp;
    public float currentHp;

    static public int emp = 0;
    int key = 0;
    int coin = 0;


    void Update()
    {
       // hpbar.value = currentHp / maxHp;   

    }
private void OnTriggerEnter2D(Collider2D collision)
{
        //����� ���˽� ����� ������� ���� �������� 1����
        if (collision.gameObject.tag == "Key")
        {
            key++;
            Destroy(collision.gameObject);
        }
        //�������ΰ� ���˽� ���������� ������� �������� �������� 1����
        if (collision.gameObject.tag == "StatCoin")
        {
            GameManager.StatCoin += 1;
            Destroy(collision.gameObject);
        }
        //emp�� ���˽� emp1�� ����
        if (collision.gameObject.tag == "emp")
        {
            emp++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "coin")
        {
            coin++;
            Destroy(collision.gameObject);
        }
    }
}
