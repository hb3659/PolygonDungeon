using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 게임 내에서 보여지는 데이터
public class PlayerData : CharacterData
{
    [SerializeField]
    protected string _playerName;
    [SerializeField]
    protected int _level;
    [SerializeField]
    protected int _mana;
    [SerializeField]
    protected int _maxMana;
    [SerializeField]
    protected float _exp;
    [SerializeField]
    protected int _gold;

    public string PlayerName { get { return _playerName; } set { _playerName = value; } }
    public int Level { get { return _level; } set { _level = value; } }
    public int Mana { get { return _mana; } set { _mana = value; } }
    public int MaxMana { get { return _maxMana; } set { _maxMana = value; } }
    public float Exp { get { return _exp; } set { _exp = value; } }
    public int Gold { get { return _gold; } set { _gold = value; } }

    private void Awake()
    {
        // 캐릭터 이름
        // 캐릭터 직업
        _level = 1;
        _HP = 300;
        _maxHP = 300;
        _mana = 200;
        _maxMana = 200;
        _offensivePower = 50;
        _defensivePower = 30;
        _exp = 0f;
        _gold = 0;
    }
}
