using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSummoner : MonoBehaviour
{
    public GameObject[] monster;
    public int Num = 0;

    public int EnemyDie = 0;

    public int DieCount = 0;

    public GameObject OpenDoor;
    public GameObject OpenDoor1;
    public GameObject OpenDoor2;
    public GameObject OpenDoor3;

    // Start is called before the first frame update
    void Start()
    {
        DieCount = Num;
        /*OpenDoor = GameObject.Find("Door");
        OpenDoor1 = GameObject.Find("Door (1)");
        OpenDoor2 = GameObject.Find("Door (2)");
        OpenDoor3 = GameObject.Find("Door (3)");*/
    }

    // Update is called once per frame
    void Update()
    {
        if (DieCount <= EnemyDie)
        {
            OpenDoor.GetComponent<Door>().isClear = true;         
            OpenDoor1.GetComponent<Door>().isClear = true;
            OpenDoor2.GetComponent<Door>().isClear = true;
            OpenDoor3.GetComponent<Door>().isClear = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("플레이어 입성");

            Summon();
        }
    }

    void Summon()
    {
        Debug.Log("바깥");
        for (int i = 0; i < Num; i++)
        {
            Debug.Log("안");
            monster[i].SetActive(true);
        }
    }
}
