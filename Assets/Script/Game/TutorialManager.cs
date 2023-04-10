using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public GameObject TextUI;
    int TextCount = 0;
    int scenarioCount = 0;
    public Text scenario;
    string[][] Talk = new string[][]
    {
        new string[]{ "안녕하세요. \n저는 사전 교육 담당자 AI 알파입니다."," 해당 공간은 실전으로 들어가기 전 사전 교육하기 위한 공간입니다. ","지루할 수도 있겠지만 총 5단계로 이루어져 있는 해당 교육을 잘 받으시면 동굴의 어려움을 잘 해쳐 나갈 수 있을 겁니다."," "},
        new string[]{ "첫 번째 교육입니다.","이렇게 많은 총알이 날라오면 어떻게 대처해야 할까요?","바로 대시입니다.\n( 마우스 ‘오른쪽 클릭＇을 통해 사용할 수 있습니다. )","대시를 하게 되면 적 공격에 대한 피해를 무효화할 수 있습니다.","다만, 알맞은 타이밍에 써야 피해를 무효화할 수 있습니다."," "},
        new string[]{ "두 번째 교육입니다.","이번에도 많은 총알이 날라오네요.\n앞서말씀드린 대쉬로는 피할수 없어 보입니다.","그럴경우 어떻게 해야 할까요?","바로 EMP폭탄을 사용하는 것입니다.\n( 키보드 ‘Space Bar’를 통해 사용할 수 있습니다. )","해당 아이템을 사용하면 눈 앞에 있는 총알 없앨 수 있습니다.","하지만 언제나 쓸 수 있는 것은 아니니 아껴서 사용하셔야 합니다."," "},
        new string[]{ "세 번째 교육입니다.","앞에 있는 USB를 사용하여 금고를 열 수 있습니다.","금고를 열면 무기 또는 아이템을 얻을 수 있습니다.","이번 교육에서는 무기와 추가로 재화를 넣어 놓았습니다.\n( USB를 소지한 상태에서 금고 근처로 가서 키보드 ‘E’를 통해 열 수 있습니다."," "},
        new string[]{ "네 번째 교육입니다.","이제 무기를 얻었으니 사용 방법을 알려드리겠습니다.","일반적인 총과 비슷하지만 특이한 점이 있습니다.","해당 총기는 등에 매는 배터리 팩에 있는 전기를 사용하여 발사 총입니다.","따라서 총을 쏘면 전기가 소모되고 전부 다 소모되면 해당 탐험은 종료되어 로비로 소환되게 됩니다.","하지만 충전할 수 있는 방법도 있습니다.\n재장전을 하거나 보유 재화를 사용하여 충전할 수 있습니다.","저희의 특별한 기술을 통해 소모된 양의 일부를 재장전 시 충전됩니다.\n또한 저희에게 재화를 보내시면 충전해드리는 서비스를 진행하고 있습니다.","하지만 많이 사용할 수록 비용이 올라가니 그 점은 주의해 주시길 바랍니다.","그럼 앞에 있는 벽을 파괴하고 나아가시면 되겠습니다."," "},
        new string[]{ "여기까지 막힘 없이 오신 걸 보면 역시 우등생 답습니다.","이제는 동굴에 들어가기 전 실제 몬스터를 소환해 드리겠습니다.","처지하고 출구로 나가시면 되겠습니다.","이상으로 사전 교육 담당자 AI 알파였습니다."," "},
    };

    public void TutorialText()
    {
        if (Talk[scenarioCount][TextCount] == " ")
        {
            scenarioCount++;
            TextCount = 0;
            Shooting.atkCool = false;
            Time.timeScale = 1;
            TextUI.SetActive(false);
        }
        else
        {
        scenario.text = Talk[scenarioCount][TextCount];
        TextCount++;
        }
    }
}
