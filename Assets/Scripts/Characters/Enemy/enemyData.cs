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

public class enemyData : CharacterData
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
        switch (CharID)
        {
            case (201):
                _enemyName = "π⁄¡„";
                break;
            case (202):
                _enemyName = "∞≈πÃ";
                break;
            case (203):
                _enemyName = "ΩΩ∂Û¿”";
                break;
            case (204):
                _enemyName = "∞°Ω√∞≈∫œ";
                break;
            case (205):
                _enemyName = "Ω∫ƒÃ∑π≈Ê";
                break;
            case (206):
                _enemyName = "ø¿≈©";
                break;
            case (207):
                _enemyName = "Ωƒ¿ŒΩƒπ∞";
                break;
            case (208):
                _enemyName = "∏ﬁ¿Ã¡ˆ";
                break;
            case (209):
                _enemyName = "∞Ò∑Ω";
                break;
            case (210):
                _enemyName = "µÂ∑°∞Ô";
                break;
        }
    }
}
