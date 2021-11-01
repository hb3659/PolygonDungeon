using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadGameButtonMng : MonoBehaviour
{
    [SerializeField]
    private Image EmptyPopUpPanel;

    public void BackButton()
    {
        FadeMng.Instance.Fade(0, 1);
        SceneMng.Instance.changeScene("TitleScene");
    }

    public void SlotButton()
    {
        EmptyPopUpPanel.gameObject.SetActive(true);
    }

    public void ExitButton()
    {
        EmptyPopUpPanel.gameObject.SetActive(false);
    }

    public void NewGameCreate()
    {
        FadeMng.Instance.Fade(0, 1);
        GameManager.Instance.NextScene = "SelectScene";
        SceneMng.Instance.changeSceneAsync("LoadingScene");
    }
}
