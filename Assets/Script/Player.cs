using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Slider hpbar;
    public float maxHp;
    public float currentHp;

    //�÷��̾��� ���� ����
    int key = 0;


    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Update()
    {
       // hpbar.value = currentHp / maxHp;   

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //����� ���˽� ����� ������� ���� �������� 1����
        if (collision.gameObject.tag == "Key")
        {
            key++;
            Destroy(collision.gameObject);
        }
        //�������ΰ� ���˽� ���������� ������� �������� �������� 1����
        else if (collision.gameObject.tag == "StatCoin")
        {
            GameManager.StatCoin += 1;
            Destroy(collision.gameObject);
        }
    }
}
