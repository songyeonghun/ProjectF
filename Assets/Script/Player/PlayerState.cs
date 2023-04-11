using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerState : MonoBehaviour
{
    //������ ����
    static public int statHp;
    static public int statAtk;
    static public int statMoveSpeed;
    static public int statAtkSpeed;
    static public int StatHpRegen;

    public Text StatCoinText;
    public Text[] needStatCoin;
    public int statNum;

    //�������� ������
    int []useCoin = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19 };


    //����ǥ
    static public int[][] stat = new int[5][]
    {
        new int[]{ 300,320,340,360,380,400,420,440,460,480,500},    //0 ä��
        new int[]{ 0,0,2,0,4,0,6,0,8,0,10},                                 //1 ���ݷ�
        new int[]{ 10,11,12,13,14,15},                                    //2 �̵��ӵ�
        new int[]{ 10, 0, 11, 0, 12, 0, 13, 0, 14, 0, 15},                //3 ���ݼӵ�
        new int[]{ 50, 0, 55, 0, 60, 0, 65, 0, 70, 0, 80}                 //5 ä��ȸ��
    };

    void Awake()
    {
        //������ ������ �ҷ�����
        statHp = PlayerPrefs.GetInt("statHp");
        statAtk = PlayerPrefs.GetInt("statAtk");
        statMoveSpeed = PlayerPrefs.GetInt("statMoveSpeed");
        statAtkSpeed = PlayerPrefs.GetInt("statAtkSpeed");
        StatHpRegen = PlayerPrefs.GetInt("StatHpRegen");
        needStatCoin[0].text = "" + useCoin[statHp];
        needStatCoin[1].text = "" + useCoin[statAtk];
        needStatCoin[2].text = "" + useCoin[statAtkSpeed];
        needStatCoin[3].text = "" + useCoin[statMoveSpeed];
        needStatCoin[4].text = "" + useCoin[StatHpRegen];

        StatCoinText.text = GameManager2.StatCoin + "Coin";
    }


    //���Ⱦ�
    public void HpUp()
    {
        if (statHp < 10 && GameManager2.StatCoin >= useCoin[statHp])
        {
            UseCoin(statHp);
            statHp++;                                                               //�ش� ���� ������
            PlayerPrefs.SetInt("statHp", statHp);                                   //���� ���� ����
            needStatCoin[0].text = "" + useCoin[statHp];
            Player.MaxHp = stat[0][statHp];
            Player.CurrentHp = Player.MaxHp;

        }
        Debug.Log(statHp);
    }
    public void AtkUp()
    {
        if (statAtk < 10 && GameManager2.StatCoin >= useCoin[statAtk])
        {
            UseCoin(statAtk);
            statAtk +=2;
            PlayerPrefs.SetInt("statAtk", statAtk);
            needStatCoin[1].text = "" + useCoin[statAtk];
        }
        Debug.Log(statAtk);
    }
    public void AtkSpeedUp()
    {
        if (statAtkSpeed < 10 && GameManager2.StatCoin >= useCoin[statAtkSpeed])
        {
            UseCoin(statAtkSpeed);
            statAtkSpeed += 2;
            PlayerPrefs.SetInt("statAtkSpeed", statAtkSpeed);
            needStatCoin[2].text = "" + useCoin[statAtkSpeed];
        }

        Debug.Log(statAtkSpeed);
    }
    public void MoveSpeedUp()
    {
        if (statMoveSpeed < 5 && GameManager2.StatCoin >= useCoin[statMoveSpeed])
        {
            UseCoin(statMoveSpeed);
            statMoveSpeed++;
            PlayerPrefs.SetInt("statMoveSpeed", statMoveSpeed);
            needStatCoin[3].text = "" + useCoin[statMoveSpeed];
        }
        Debug.Log(statMoveSpeed);
    }

    public void HpRegenUp()
    {
        if (StatHpRegen < 10 && GameManager2.StatCoin >= useCoin[StatHpRegen])
        {
            UseCoin(StatHpRegen);
            StatHpRegen +=2;
            PlayerPrefs.SetInt("StatHpRegen", StatHpRegen);
            needStatCoin[4].text = "" + useCoin[StatHpRegen];
        }

        Debug.Log(StatHpRegen);
    }


    void UseCoin(int A)
    {
        GameManager2.StatCoin -= useCoin[A];                                //���� �Ҹ�
        GameManager2.SaveCoin();                                                    //�Ҹ�� ������ ����
        StatCoinText.text = GameManager2.StatCoin + "Coin";                      //���� ���� �ý�Ʈ ����
    }
}
