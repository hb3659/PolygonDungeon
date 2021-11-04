using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : MonoBehaviour
{
    [SerializeField]
    protected int _charID;
    [SerializeField]
    protected int _HP;
    [SerializeField]
    protected int _maxHP;
    [SerializeField]
    protected float _offensivePower;
    [SerializeField]
    protected float _defensivePower;

    public int CharID { get { return _charID; } set { _charID = value; } }
    public int HP { get { return _HP; } set { _HP = value; } }
    public int MaxHP { get { return _maxHP; } set { _maxHP = value; } }
    public float OffensivePower { get { return _offensivePower; } set { _offensivePower = value; } }
    public float DefensivePower { get { return _defensivePower; } set { _defensivePower = value; } }
}
