using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class JSONCharExplain
{
    public List<string> charName = new List<string>();
    public List<string> charScript = new List<string>();

    public JSONCharExplain() { }

    public JSONCharExplain(int charLength)
    {
        charName.Add("전사");
        charName.Add("궁수");
        charName.Add("마법사");

        charScript.Add("전사는 강한 공격력과 체력을 지니고 있는 직업으로 전투 상황에서는 최전선에서 그 진가를 발휘하게 됩니다. 전사와 함께 모험을 떠나시겠습니까?");
        charScript.Add("민첩성과 힘을 지닌 궁수는 적을 공격함에 있어 백발백중의 높은 명중률을 자랑하는 직업입니다. 궁수와 함께 모험을 떠나시겠습니까?");
        charScript.Add("고대의 지식을 탐구하는 것을 일생일대의 과업으로 여기는 마법사는 높은 지능을 요구하는 직업입니다. 마법사와 함께 모험을 떠나시겠습니까?");
    }
}
