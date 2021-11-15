using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadSceneMng : MonoBehaviour
{
    [HideInInspector]
    public string job;
    
    [SerializeField]
    private Text[] texts;
    [SerializeField]
    private Button[] delButtons;

    [SerializeField]
    private LoadGameButtonMng btnMng;

    void Start()
    {
        FadeMng.Instance.Fade(1, 0);

        try
        {
            // json ������ �����Ѵٸ� �ش� ������ �ҷ��´�.
            SaveSlotMng.Instance.fileLoad();
        }

        catch (Exception e)
        {
            // �ƴ϶�� ���ο� ������ ������ �� �ҷ��´�.
            SaveSlotMng.Instance.fileSave();
            SaveSlotMng.Instance.fileLoad();
        }

        textSet();
    }

    public void textSet()
    {
        for (int i = 0; i < GameManager.Instance.saveSlotCount; i++)
        {
            if (SaveSlotMng.Instance.slotData.isFull[i] == false)
            {
                texts[i].text = "�� ����";
                delButtons[i].gameObject.SetActive(false);
            }
            else
            {
                job = null;

                switch (SaveSlotMng.Instance.slotData.id[i])
                {
                    case 101:
                        job = "����";
                        break;
                    case 102:
                        job = "�ü�";
                        break;
                    case 103:
                        job = "������";
                        break;
                }

                // ����� ������ ǥ��
                texts[i].text =
                    "Lv." + SaveSlotMng.Instance.slotData.playerLevel[i] + " " +
                    job + " " +
                    SaveSlotMng.Instance.slotData.playerName[i] +
                    "\n" + SaveSlotMng.Instance.slotData.saveTime[i];

                delButtons[i].gameObject.SetActive(true);
            }
        }
    }
}
