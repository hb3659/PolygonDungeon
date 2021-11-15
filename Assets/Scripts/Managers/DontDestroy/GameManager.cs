using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                return null;

            return instance;
        }
    }

    // 로딩 화면 이후의 씬 정보
    private string nextScene;
    private string currentScene;

    // 세이브 슬롯의 개수
    [HideInInspector]
    public int saveSlotCount = 3;

    // 선택된 인덱스의 슬롯을 이용한다.
    private int selectedSaveSlot;

    #region Scene Property
    public string NextScene
    {
        get { return nextScene; }
        set { nextScene = value; }
    }
    public string CurrentScene
    {
        get { return currentScene; }
        set { currentScene = value; }
    }
    #endregion

    #region Player Property
    public int SelectedSaveSlot
    {
        get { return selectedSaveSlot; }
        set { selectedSaveSlot = value; }
    }
    #endregion

    void Awake()
    {
        Singleton();
    }

    void Singleton()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }
}
