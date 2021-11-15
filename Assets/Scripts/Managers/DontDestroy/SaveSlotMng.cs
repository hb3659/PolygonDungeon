using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSlotMng : MonoBehaviour
{
    private static SaveSlotMng instance;

    [HideInInspector]
    public JSONSlotData slotData;
    //[HideInInspector]
    //public JSONSaveTransform transformData;

    [HideInInspector]
    public int slotCount;
    [HideInInspector]
    public string path;

    void Start()
    {
        slotCount = GameManager.Instance.saveSlotCount;
        path = Application.dataPath + "/Resources/JSON";
    }

    public static SaveSlotMng Instance
    {
        get
        {
            if (instance == null)
                return null;

            return instance;
        }
    }

    void Awake()
    {
        Singleton();
        slotData = null;
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

    public void fileSave()
    {
        if (slotData == null)
        {
            // 새로운 세이브 파일을 다시 생성하기 때문에 파일이 저장되지 않는다.
            // 따라서 saveSlot 이 비어있다면 새로운 JSONSaveSlot 을 생성해준다.
            slotData = new JSONSlotData(slotCount);
        }

        string jsonData = JSONCreator.Instance.ObjectToJson(slotData);
        JSONCreator.Instance.CreateJsonFile(path, "SavedGameData", jsonData);

        Debug.Log("Save!");
    }

    public void fileLoad()
    {
        slotData = JSONCreator.Instance.LoadJsonFile<JSONSlotData>(path, "SavedGameData");

        Debug.Log("Load!");
    }
}
