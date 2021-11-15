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
            // json 파일이 존재한다면 해당 파일을 불러온다.
            SaveSlotMng.Instance.fileLoad();
        }

        catch (Exception e)
        {
            // 아니라면 새로운 파일을 저장한 후 불러온다.
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
                texts[i].text = "빈 슬롯";
                delButtons[i].gameObject.SetActive(false);
            }
            else
            {
                job = null;

                switch (SaveSlotMng.Instance.slotData.id[i])
                {
                    case 101:
                        job = "전사";
                        break;
                    case 102:
                        job = "궁수";
                        break;
                    case 103:
                        job = "마법사";
                        break;
                }

                // 저장된 정보를 표시
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
