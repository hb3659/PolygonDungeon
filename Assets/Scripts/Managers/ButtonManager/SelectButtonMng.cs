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

    int charIndex;

    void Start()
    {
        charIndex = 0;
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
        FadeMng.Instance.Fade(0, 1);
        GameManager.Instance.NextScene = "GameScene";
        SceneMng.Instance.changeSceneAsync("LoadingScene");
    }

    public void ExitButton()
    {
        checkPanel.gameObject.SetActive(false);
    }

    public void RightArrow()
    {
        sceneMng.characters[charIndex].SetActive(false);

        charIndex++;

        if (charIndex > sceneMng.characters.Length - 1)
            charIndex = 0;

        sceneMng.characters[charIndex].SetActive(true);
        sceneMng.charJob.text = sceneMng.charExplain.charName[charIndex];
        sceneMng.charScript.text = sceneMng.charExplain.charScript[charIndex];
    }

    public void LeftArrow()
    {
        sceneMng.characters[charIndex].SetActive(false);

        charIndex--;

        if (charIndex < 0)
            charIndex = sceneMng.characters.Length - 1;

        sceneMng.characters[charIndex].SetActive(true);
        sceneMng.charJob.text = sceneMng.charExplain.charName[charIndex];
        sceneMng.charScript.text = sceneMng.charExplain.charScript[charIndex];
    }
}
