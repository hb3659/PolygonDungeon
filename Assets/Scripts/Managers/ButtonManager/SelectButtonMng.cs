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
    [HideInInspector]
    public int charID;

    void Start()
    {
        charIndex = 0;
        charID = 101;
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
            noName.SetTrigger("NoName");
        else
        {
            // 캐릭터 정보 저장


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
    }
}
