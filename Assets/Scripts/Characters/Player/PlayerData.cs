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
    protected float _mana;
    [SerializeField]
    protected float _maxMana;
    [SerializeField]
    protected float _exp;
    [SerializeField]
    protected float _maxExp;
    [SerializeField]
    protected int _gold;

    public string PlayerName { get { return _playerName; } set { _playerName = value; } }
    public int Level { get { return _level; } set { _level = value; } }
    public float Mana { get { return _mana; } set { _mana = value; } }
    public float MaxMana { get { return _maxMana; } set { _maxMana = value; } }
    public float Exp { get { return _exp; } set { _exp = value; } }
    public float MaxExp { get { return _maxExp; } set { _maxExp = value; } }
    public int Gold { get { return _gold; } set { _gold = value; } }
}
