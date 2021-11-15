using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerThirdCamera : MonoBehaviour
{
    // 새로 생성된 캐릭터를 따라다니는 카메라
    public CinemachineFreeLook thirdCam;
    public GameSceneMng sceneMng;

    void Start()
    {
        thirdCam.Follow = sceneMng.player.transform;
        thirdCam.LookAt = sceneMng.player.transform;
    }
}
