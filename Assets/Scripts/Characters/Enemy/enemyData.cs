using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyID
{
    Bat = 201,
    Spider,
    Slime,
    TurtleShell,
    Skeleton,
    Orc,
    MonsterPlant,
    EvilMage,
    Golem,
    Dragon,
}

public class EnemyData : CharacterData
{
    [SerializeField]
    protected string _enemyName;
    [SerializeField]
    protected float _exp;
    [SerializeField]
    protected int _gold;

    public string EnemyName { get { return _enemyName; } set { _enemyName = value; } }
    public float Exp { get { return _exp; } set { _exp = value; } }
    public int Gold { get { return _gold; } set { _gold = value; } }

    void Awake()
    {
        SetName();
    }

    void SetName()
    {
        // 적의 아이디 값을 미리 할당하자
        switch (ID)
        {
            case (201):
                _enemyName = "박쥐";
                break;
            case (202):
                _enemyName = "거미";
                break;
            case (203):
                _enemyName = "슬라임";
                break;
            case (204):
                _enemyName = "가시거북";
                break;
            case (205):
                _enemyName = "스켈레톤";
                break;
            case (206):
                _enemyName = "오크";
                break;
            case (207):
                _enemyName = "식인식물";
                break;
            case (208):
                _enemyName = "메이지";
                break;
            case (209):
                _enemyName = "골렘";
                break;
            case (210):
                _enemyName = "드래곤";
                break;
        }
    }
}
