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

    //�������
    public Text HPText;
    public Text AtkText;
    public Text MoveSpeedText;
    public Text AtkSpeedText;
    public Text HPRegenText;
    public Text StatCoinText;

    //�������� ������
    int []useCoin = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19 };


    //����ǥ
    static public int[][] stat = new int[5][]
    {
        new int[]{ 300,320,340,360,380,400,420,440,460,480,500},    //0 ä��
        new int[]{ 0,0,2,0,4,0,6,0,8,0,10},                            //1 ���ݷ�
        new int[]{ 10,11,12,13,14,15},                                    //2 �̵��ӵ�
        new int[]{ 10, 0, 11, 0, 12, 0, 13, 0, 14, 0, 15},                //3 ���ݼӵ�
        new int[]{ 50, 0, 55, 0, 60, 0, 65, 0, 70, 0, 80}                 //5 ä��ȸ��
    };

    void Start()
    {
        //������ ������ �ҷ�����
        statHp = PlayerPrefs.GetInt("statHp");
        statAtk = PlayerPrefs.GetInt("statAtk");
        statMoveSpeed = PlayerPrefs.GetInt("statMoveSpeed");
        statAtkSpeed = PlayerPrefs.GetInt("statAtkSpeed");
        StatHpRegen = PlayerPrefs.GetInt("StatHpRegen");


        //����â�� ����� ���� ǥ��
        HPText.text = "Level: " + statHp + "\nHP: " + stat[0][statHp];
        AtkText.text = "Level: " + statAtk + "\nATK: " + stat[1][statAtk];
        MoveSpeedText.text = "Level: " + statMoveSpeed + "\nMoveSpeed: " + stat[2][statMoveSpeed];
        AtkSpeedText.text = "Level: " + statAtkSpeed + "\nAtkSpeed: " + stat[3][statAtkSpeed];
        HPRegenText.text = "Level: " + StatHpRegen + "\nHpRegen: " + stat[4][StatHpRegen] + "%";
        StatCoinText.text = GameManager.StatCoin + "Coin";
    }


    //���Ⱦ�
    public void HpUp()
    {
        if (statHp < 10 && GameManager.StatCoin >= useCoin[statHp])
        {
            GameManager.StatCoin -= useCoin[statHp];                                //���� �Ҹ�
            StatCoinText.text = GameManager.StatCoin + "Coin";                      //���� ���� �ý�Ʈ ����
            statHp++;                                                               //�ش� ���� ������
            HPText.text = "Level: " + statHp + "\nHP: " + stat[0][statHp];          //�ش� ���� ��ġ �ý�Ʈ ����
            PlayerPrefs.SetInt("statHp", statHp);                                   //���� ���� ����

        }
        Debug.Log(statHp);
    }
    public void AtkUp()
    {
        if (statAtk < 10 && GameManager.StatCoin >= useCoin[statAtk])
        {
            GameManager.StatCoin -= useCoin[statAtk];                                //���� �Ҹ�
            StatCoinText.text = GameManager.StatCoin + "Coin";                      //���� ���� �ý�Ʈ ����
            statAtk+=2;
            AtkText.text = "Level: " + statAtk/2 + "\nATK: " + stat[1][statAtk];
            PlayerPrefs.SetInt("statAtk", statAtk);
        }
        Debug.Log(statAtk);
    }
    public void MoveSpeedUp()
    {
        if (statMoveSpeed < 5 && GameManager.StatCoin >= useCoin[statMoveSpeed])
        {
            GameManager.StatCoin -= useCoin[statMoveSpeed];                                //���� �Ҹ�
            StatCoinText.text = GameManager.StatCoin + "Coin";                      //���� ���� �ý�Ʈ ����
            statMoveSpeed++;
            MoveSpeedText.text = "Level: " + statMoveSpeed + "\nMoveSpeed: " + stat[2][statMoveSpeed];
            PlayerPrefs.SetInt("statMoveSpeed", statMoveSpeed);
        }
        Debug.Log(statMoveSpeed);
    }
    public void AtkSpeedUp()
    {
        if (statAtkSpeed < 10 && GameManager.StatCoin >= useCoin[statAtkSpeed])
        {
            GameManager.StatCoin -= useCoin[statAtkSpeed];                                //���� �Ҹ�
            StatCoinText.text = GameManager.StatCoin + "Coin";                      //���� ���� �ý�Ʈ ����
            statAtkSpeed+=2;
            AtkSpeedText.text = "Level: " + statAtkSpeed/2 + "\nAtkSpeed: " + stat[3][statAtkSpeed];
            PlayerPrefs.SetInt("statAtkSpeed", statAtkSpeed);
        }

        Debug.Log(statAtkSpeed);
    }

    public void HpRegenUp()
    {
        if (StatHpRegen < 10 && GameManager.StatCoin >= useCoin[StatHpRegen])
        {
            GameManager.StatCoin -= useCoin[StatHpRegen];                                //���� �Ҹ�
            StatCoinText.text = GameManager.StatCoin + "Coin";                      //���� ���� �ý�Ʈ ����
            StatHpRegen+=2;
            HPRegenText.text = "Level: " + StatHpRegen/2 + "\nHpRegen: " + stat[4][StatHpRegen] + "%";
            PlayerPrefs.SetInt("StatHpRegen", StatHpRegen);
        }

        Debug.Log(StatHpRegen);
    }


    //�׽�Ʈ��
    static public void coinadd()
    {
        //StatCoinText.text = GameManager.StatCoin + "Coin";
    }

}
