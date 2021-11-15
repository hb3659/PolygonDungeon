using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadGameButtonMng : MonoBehaviour
{
    private int slotIndex;

    [SerializeField]
    private Image EmptyPopUpPanel;
    [SerializeField]
    private Image FullPopUpPanel;
    [SerializeField]
    private Image DeletePopUpPanel;

    [SerializeField]
    public Button[] slots;
    [SerializeField]
    private Text deleteData;

    [SerializeField]
    private LoadSceneMng sceneMng;

    public void BackButton()
    {
        FadeMng.Instance.Fade(0, 1);
        SceneMng.Instance.changeScene("TitleScene");
    }

    // 세이브 슬롯 버튼
    public void SlotButton(int index)
    {
        // 선택된 슬롯의 번호를 저장
        GameManager.Instance.SelectedSaveSlot = index;

        if (SaveSlotMng.Instance.slotData.isFull[index] == false)
        {
            // 슬롯이 비었을 경우 새로운 게임 생성 팝업 띄운다.
            EmptyPopUpPanel.gameObject.SetActive(true);
        }
        else
        {
            // 아니라면 불러오기 팝업을 띄운다.
            FullPopUpPanel.gameObject.SetActive(true);
        }
    }

    public void ExitButton()
    {
        EmptyPopUpPanel.gameObject.SetActive(false);
        FullPopUpPanel.gameObject.SetActive(false);
        DeletePopUpPanel.gameObject.SetActive(false);
    }

    // 팝업에서의 게임 생성 버튼
    public void NewGameCreate()
    {
        FadeMng.Instance.Fade(0, 1);
        GameManager.Instance.NextScene = "SelectScene";
        SceneMng.Instance.changeSceneAsync("LoadingScene");
    }

    // 팝업에서의 게임 불러오기 버튼
    public void GameLoadButton()
    {
        int index = GameManager.Instance.SelectedSaveSlot;

        FadeMng.Instance.Fade(0, 1);
        GameManager.Instance.NextScene = "GameScene";
        SceneMng.Instance.changeSceneAsync("LoadingScene");
    }

    public void CkeckDeleteButton(int index)
    {
        slotIndex = index;

        // 삭제 확인 팝업
        DeletePopUpPanel.gameObject.SetActive(true);

        // 팝업 텍스트 내용
        deleteData.text = "Lv." + SaveSlotMng.Instance.slotData.playerLevel[index] + " " +
                    sceneMng.job + " " +
                    SaveSlotMng.Instance.slotData.playerName[index] +
                    "\n 해당 게임을 삭제하시겠습니까?";
    }

    public void DateDelete()
    {
        // isFull을 false로만 설정해도 해당 슬롯의 데이터는 빈 것으로 판단한다.
        // 추후에 새로운 데이터를 생성하면 이전 데이터는 덮이므로 상관 없다.
        SaveSlotMng.Instance.slotData.isFull[slotIndex] = false;

        SaveSlotMng.Instance.fileSave();
        SaveSlotMng.Instance.fileLoad();

        DeletePopUpPanel.gameObject.SetActive(false);

        sceneMng.textSet();
    }
}
