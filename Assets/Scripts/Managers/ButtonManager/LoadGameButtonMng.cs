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

    // ���̺� ���� ��ư
    public void SlotButton(int index)
    {
        // ���õ� ������ ��ȣ�� ����
        GameManager.Instance.SelectedSaveSlot = index;

        if (SaveSlotMng.Instance.slotData.isFull[index] == false)
        {
            // ������ ����� ��� ���ο� ���� ���� �˾� ����.
            EmptyPopUpPanel.gameObject.SetActive(true);
        }
        else
        {
            // �ƴ϶�� �ҷ����� �˾��� ����.
            FullPopUpPanel.gameObject.SetActive(true);
        }
    }

    public void ExitButton()
    {
        EmptyPopUpPanel.gameObject.SetActive(false);
        FullPopUpPanel.gameObject.SetActive(false);
        DeletePopUpPanel.gameObject.SetActive(false);
    }

    // �˾������� ���� ���� ��ư
    public void NewGameCreate()
    {
        FadeMng.Instance.Fade(0, 1);
        GameManager.Instance.NextScene = "SelectScene";
        SceneMng.Instance.changeSceneAsync("LoadingScene");
    }

    // �˾������� ���� �ҷ����� ��ư
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

        // ���� Ȯ�� �˾�
        DeletePopUpPanel.gameObject.SetActive(true);

        // �˾� �ؽ�Ʈ ����
        deleteData.text = "Lv." + SaveSlotMng.Instance.slotData.playerLevel[index] + " " +
                    sceneMng.job + " " +
                    SaveSlotMng.Instance.slotData.playerName[index] +
                    "\n �ش� ������ �����Ͻðڽ��ϱ�?";
    }

    public void DateDelete()
    {
        // isFull�� false�θ� �����ص� �ش� ������ �����ʹ� �� ������ �Ǵ��Ѵ�.
        // ���Ŀ� ���ο� �����͸� �����ϸ� ���� �����ʹ� ���̹Ƿ� ��� ����.
        SaveSlotMng.Instance.slotData.isFull[slotIndex] = false;

        SaveSlotMng.Instance.fileSave();
        SaveSlotMng.Instance.fileLoad();

        DeletePopUpPanel.gameObject.SetActive(false);

        sceneMng.textSet();
    }
}
