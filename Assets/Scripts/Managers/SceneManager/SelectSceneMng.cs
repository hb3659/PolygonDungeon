using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectSceneMng : MonoBehaviour
{
    [Header("Reference Variables")]
    public Transform charTransform;
    public Transform camTransform;
    public Image explainPanel;

    [HideInInspector]
    public GameObject[] characters;

    public JSONCharExplain charExplain;

    [Header("Explain")]
    [SerializeField]
    public Text charJob;
    [SerializeField]
    public Text charScript;

    [Header("Value Variables")]
    private bool isArrive = true;


    void Start()
    {
        explainPanel.gameObject.SetActive(false);

        FadeMng.Instance.Fade(1, 0);

        createPrefabs();
        characterInfoSave();
        characterInfoLoad();

        characterInfo();
    }

    void Update()
    {
        if (isArrive)
            OpenUI();
    }

    void createPrefabs()
    {
        // 맵 생성
        GameObject map = Resources.Load<GameObject>("Prefabs/Environments/Center_Hall");

        // 캐릭터 생성
        GameObject warrior = Resources.Load<GameObject>("Prefabs/Characters/Warrior");
        GameObject archer = Resources.Load<GameObject>("Prefabs/Characters/Archer");
        GameObject wizard = Resources.Load<GameObject>("Prefabs/Characters/Wizard");

        Instantiate(map);

        Instantiate(warrior, charTransform.position, charTransform.rotation).transform.SetParent(charTransform);
        Instantiate(archer, charTransform.position, charTransform.rotation).transform.SetParent(charTransform);
        Instantiate(wizard, charTransform.position, charTransform.rotation).transform.SetParent(charTransform);
        characters = new GameObject[charTransform.childCount];

        for (int i = 0; i < charTransform.childCount; i++)
        {
            characters[i] = charTransform.GetChild(i).gameObject;
            characters[i].SetActive(false);
        }

        characters[0].SetActive(true);
    }

    void OpenUI()
    {
        if (Camera.main.transform.position == camTransform.position)
        {
            explainPanel.gameObject.SetActive(true);

            isArrive = false;
        }
    }

    // 캐릭터 설명 정보를 json 파일로 저장
    void characterInfoSave()
    {
        charExplain = new JSONCharExplain(characters.Length);
        string jsonData = JSONCreator.Instance.ObjectToJson(charExplain);
        JSONCreator.Instance.CreateJsonFile(Application.dataPath + "/Resources/JSON", "charExplain", jsonData);
    }

    // json 파일 불러오기
    void characterInfoLoad()
    {
        JSONCreator.Instance.LoadJsonFile<JSONCharExplain>(Application.dataPath + "/Resources/JSON", "charExplain");
    }

    void characterInfo()
    {
        charJob.text = charExplain.charName[0];
        charScript.text = charExplain.charScript[0];
    }
}