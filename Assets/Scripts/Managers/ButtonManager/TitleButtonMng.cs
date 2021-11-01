using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleButtonMng : MonoBehaviour
{
    public void NewGameButton()
    {
        FadeMng.Instance.Fade(0, 1);
        SceneMng.Instance.changeScene("LoadGameScene");
    }

    public void LoadGameButton()
    {
        FadeMng.Instance.Fade(0, 1);
        SceneMng.Instance.changeScene("LoadGameScene");
    }

    public void QuitButton()
    {
        FadeMng.Instance.Fade(0, 1);
        Application.Quit();
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
    }
}