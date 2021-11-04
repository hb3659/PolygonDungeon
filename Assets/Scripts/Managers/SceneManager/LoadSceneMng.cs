using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadSceneMng : MonoBehaviour
{
    [SerializeField]
    private Text texts;

    void Start()
    {
        FadeMng.Instance.Fade(1, 0);
    }

    // 저장된 게임 데이터 저장
    void ExistenceGame()
    {
        //JSONSaveSlot saveSlot = new JSONSaveSlot(true);
        //string jsondata = JSONCreator.Instance.ObjectToJson(saveSlot);
        //JSONCreator.Instance.CreateJsonFile(Application.dataPath + "/Resources/JSON", "SavedGame", jsondata);
    }
}
