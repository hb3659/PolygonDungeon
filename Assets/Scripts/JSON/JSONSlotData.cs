using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ����� ���� ������
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
    // ������
    // ���
    // ��ų

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
