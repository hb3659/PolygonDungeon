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

    // �ε� ȭ�� ������ �� ����
    private string nextScene;
    private string currentScene;

    // ���̺� ������ ����
    [HideInInspector]
    public int saveSlotCount = 3;

    // ���õ� �ε����� ������ �̿��Ѵ�.
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
