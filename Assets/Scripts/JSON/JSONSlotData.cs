using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 저장된 게임 데이터
[Serializable]
public class JSONSlotData
{
    public bool[] isFull;

    public string[] playerName;
    public int[] id;
    public int[] playerLevel;

    // playerData
    public float[] savedMaxHP;
    public float[] savedCurrentHP;
    public float[] savedMaxMana;
    public float[] savedCurrentMana;

    public float[] savedMaxExpert;
    public float[] savedCurrentExpert;

    public int[] savedGold;
    // 아이템
    // 장비
    // 스킬

    public DateTime[] saveTime;

    public JSONSlotData() { }
    public JSONSlotData(int slotNum)
    {
        isFull = new bool[slotNum];

        playerName = new string[slotNum];
        id = new int[slotNum];
        playerLevel = new int[slotNum];

        savedMaxHP = new float[slotNum];
        savedCurrentHP = new float[slotNum];
        savedMaxMana = new float[slotNum];
        savedCurrentMana = new float[slotNum];

        savedMaxExpert = new float[slotNum];
        savedCurrentExpert = new float[slotNum];

        savedGold = new int[slotNum];

        saveTime = new DateTime[slotNum];
    }
}
