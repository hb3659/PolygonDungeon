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
        // ���� ���̵� ���� �̸� �Ҵ�����
        switch (ID)
        {
            case (201):
                _enemyName = "����";
                break;
            case (202):
                _enemyName = "�Ź�";
                break;
            case (203):
                _enemyName = "������";
                break;
            case (204):
                _enemyName = "���ðź�";
                break;
            case (205):
                _enemyName = "���̷���";
                break;
            case (206):
                _enemyName = "��ũ";
                break;
            case (207):
                _enemyName = "���νĹ�";
                break;
            case (208):
                _enemyName = "������";
                break;
            case (209):
                _enemyName = "��";
                break;
            case (210):
                _enemyName = "�巡��";
                break;
        }
    }
}
