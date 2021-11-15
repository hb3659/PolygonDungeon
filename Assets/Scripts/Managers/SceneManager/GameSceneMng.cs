using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class GameSceneMng : MonoBehaviour
{
    [SerializeField]
    private Text playerName;
    [SerializeField]
    private Text playerLevel;
    [SerializeField]
    private Image HPBar;
    [SerializeField]
    private Image ManaBar;
    [SerializeField]
    private Image ExpertBar;

    [SerializeField]
    private CinemachineFreeLook thirdCam;
    [SerializeField]
    private CinemachineFreeLook aimCam;

    // 캐릭터 생성 경로
    private string charPath = "Prefabs/Characters/Players/";

    [HideInInspector]
    public GameObject player;
    private PlayerData data;

    public PlayerController pController;

    void Start()
    {
        FadeMng.Instance.Fade(1, 0);
        GameManager.Instance.CurrentScene = "GameScene";
        //pController = player.GetComponent<PlayerController>();

        CreatePlayer();
        ThirdCamSetting();
    }

    void Update()
    {
        UpdateBar();
    }


    void CreatePlayer()
    {
        int index = GameManager.Instance.SelectedSaveSlot;

        playerName.text = SaveSlotMng.Instance.slotData.playerName[index];
        playerLevel.text = SaveSlotMng.Instance.slotData.playerLevel[index].ToString();

        switch (SaveSlotMng.Instance.slotData.id[index])
        {
            case 101:
                player = Resources.Load<GameObject>(charPath + "Warrior");
                break;
            case 102:
                player = Resources.Load<GameObject>(charPath + "Archer");
                break;
            case 103:
                player = Resources.Load<GameObject>(charPath + "Wizard");
                break;
        }

        // 추후 vector3 와 quaternion 값 추가
        player = Instantiate(player);

        #region Loading Datas
        data = player.GetComponent<PlayerData>();

        data.PlayerName = SaveSlotMng.Instance.slotData.playerName[index];
        data.Level = SaveSlotMng.Instance.slotData.playerLevel[index];
        data.ID = SaveSlotMng.Instance.slotData.id[index];

        data.MaxHP = SaveSlotMng.Instance.slotData.savedMaxHP[index];
        data.HP = SaveSlotMng.Instance.slotData.savedCurrentHP[index];
        data.MaxMana = SaveSlotMng.Instance.slotData.savedMaxMana[index];
        data.Mana = SaveSlotMng.Instance.slotData.savedCurrentMana[index];

        data.MaxExp = SaveSlotMng.Instance.slotData.savedMaxExpert[index];
        data.Exp = SaveSlotMng.Instance.slotData.savedCurrentExpert[index];

        data.Gold = SaveSlotMng.Instance.slotData.savedGold[index];
        #endregion
    }

    void ThirdCamSetting()
    {
        if (player != null)
        {
            thirdCam.Follow = player.transform;
            thirdCam.LookAt = player.transform;

            aimCam.gameObject.SetActive(false);
        }
    }

    void UpdateBar()
    {
        HPBar.fillAmount = data.HP / data.MaxHP;
        ManaBar.fillAmount = data.Mana / data.MaxMana;
        ExpertBar.fillAmount = data.Exp / data.MaxExp;
    }
}
