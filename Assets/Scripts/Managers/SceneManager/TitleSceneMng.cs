using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSceneMng : MonoBehaviour
{
    public bool isPressAnyKey = false;

    void Start()
    {
        FadeMng.Instance.Fade(1, 0);
    }

    void Update()
    {
        pressAnyKey();
    }

    void pressAnyKey()
    {
        if (Input.anyKeyDown && !FadeMng.Instance.IsFade)
        {
            FadeMng.Instance.Fade(0, 1);
            SceneMng.Instance.changeScene("LoadGameScene");
        }
    }
}
