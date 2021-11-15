using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectButtonMng : MonoBehaviour
{
    [SerializeField]
    private Image checkPanel;
    [SerializeField]
    private SelectSceneMng sceneMng;
    [SerializeField]
    private Animator noName;
    [SerializeField]
    private InputField input;
    private string inputText;

    [HideInInspector]
    public int charIndex;
    // 캐릭터 아이디(직업)
    [HideInInspector]
    public int charID;

    int index;

    void Start()
    {
        charIndex = 0;
        charID = 101;
        input.characterLimit = 15;

        index = GameManager.Instance.SelectedSaveSlot;
    }

    void Update()
    {
        inputText = input.text;
    }

    public void PreviousButton()
    {
        FadeMng.Instance.Fade(0, 1);
        SceneMng.Instance.changeScene("LoadGameScene");
    }

    public void SelectButton()
    {
        checkPanel.gameObject.SetActive(true);
    }

    public void CreateButton()
    {
        if (inputText == "")
            // 플레이어의 이름을 입력하지 않으면 애니메이션 실행
            noName.SetTrigger("NoName");
        else
        {
            // 캐릭터 정보 저장
            // 플레이어의 정보에 저장되어야 한다....?
            // 21.11.11 / 슬롯에서 데이터를 가져오면 되니 일단은 주석처리
            #region Save player data in GameManager
            //GameManager.Instance.PlayerName = inputText;
            //GameManager.Instance.ID = sceneMng.charID;

            //GameManager.Instance.MaxHP = 300;
            //GameManager.Instance.CurrentHP = 300;
            //GameManager.Instance.MaxMana = 300;
            //GameManager.Instance.CurrentMana = 300;

            //GameManager.Instance.MaxExpert = 100;
            //GameManager.Instance.CurrentExpert = 0;

            //GameManager.Instance.Gold = 0;
            #endregion

            // 이후 슬롯 정보에도 저장되어야 한다.
            // 첫 세이브 버튼
            // 캐릭터 생성 후 데이터를 초기화한다.
            #region Save player data in json.
            SaveSlotMng.Instance.slotData.isFull[index] = true;

            SaveSlotMng.Instance.slotData.playerName[index] = inputText;
            SaveSlotMng.Instance.slotData.id[index] = charID;
            SaveSlotMng.Instance.slotData.playerLevel[index] = 1;
            SaveSlotMng.Instance.slotData.saveTime[index] = DateTime.Now;

            SaveSlotMng.Instance.slotData.savedMaxHP[index] = 300;
            SaveSlotMng.Instance.slotData.savedCurrentHP[index] = 300;
            SaveSlotMng.Instance.slotData.savedMaxMana[index] = 300;
            SaveSlotMng.Instance.slotData.savedCurrentMana[index] = 300;

            SaveSlotMng.Instance.slotData.savedMaxExpert[index] = 100;
            SaveSlotMng.Instance.slotData.savedCurrentExpert[index] = 0;

            SaveSlotMng.Instance.slotData.savedGold[index] = 0;
            #endregion

            SaveSlotMng.Instance.fileSave();

            FadeMng.Instance.Fade(0, 1);
            GameManager.Instance.NextScene = "GameScene";
            SceneMng.Instance.changeSceneAsync("LoadingScene");
        }
    }

    public void ExitButton()
    {
        checkPanel.gameObject.SetActive(false);
    }

    public void RightArrow()
    {
        sceneMng.characters[charIndex].SetActive(false);

        charIndex++;
        charID++;

        if (charIndex > sceneMng.characters.Length - 1)
        {
            charIndex = 0;
            charID = 101;
        }

        sceneMng.characters[charIndex].SetActive(true);
        sceneMng.charJob.text = sceneMng.charExplain.charName[charIndex];
        sceneMng.charScript.text = sceneMng.charExplain.charScript[charIndex];
        sceneMng.charID = charID;
    }

    public void LeftArrow()
    {
        sceneMng.characters[charIndex].SetActive(false);

        charIndex--;
        charID--;

        if (charIndex < 0)
        {
            charIndex = sceneMng.characters.Length - 1;
            charID = 100 + sceneMng.characters.Length;
        }

        sceneMng.characters[charIndex].SetActive(true);
        sceneMng.charJob.text = sceneMng.charExplain.charName[charIndex];
        sceneMng.charScript.text = sceneMng.charExplain.charScript[charIndex];
        sceneMng.charID = charID;
    }
}
