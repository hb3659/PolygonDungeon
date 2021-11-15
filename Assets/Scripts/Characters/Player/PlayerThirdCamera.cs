using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerThirdCamera : MonoBehaviour
{
    // ���� ������ ĳ���͸� ����ٴϴ� ī�޶�
    public CinemachineFreeLook thirdCam;
    public GameSceneMng sceneMng;

    void Start()
    {
        thirdCam.Follow = sceneMng.player.transform;
        thirdCam.LookAt = sceneMng.player.transform;
    }
}
