using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_CreateRoomPanel : UIBase
{
    public const int MAX_PLAYER = 8;
    private void OnEnable()
    {
        // create 버튼 이벤트 추가
        AddUIEvent(Get("btnCreate"), Enums.UIEvent.PointerClick, CreateRoom);
        // cancel 버튼 이벤트 추가
        AddUIEvent(Get("btnCancel"), Enums.UIEvent.PointerClick, Cancel);

        // 초기화
        Get<InputField>("RoomNameInputField").text = $"{PhotonNetwork.LocalPlayer.NickName}'s Room";
        Get<InputField>("MaxPlayerInputField").text = $"{MAX_PLAYER}";

        // 메뉴 버튼을 클릭하지 못하도록 blocker 활성화
        Get("Blocker").SetActive(true);
    }

    private void OnDisable()
    {
        // create 버튼 이벤트 제거
        RemoveUIEvent(Get("btnCreate"), Enums.UIEvent.PointerClick, CreateRoom);
        // cancel 버튼 이벤트 제거
        RemoveUIEvent(Get("btnCancel"), Enums.UIEvent.PointerClick, Cancel);

        Get("Blocker").SetActive(false);
    }

    public void CreateRoom(PointerEventData eventData)
    {
        // RoomName 확인
        if (string.IsNullOrEmpty(Get<InputField>("RoomNameInputField").text))
        {
            Debug.LogWarning("Please Input RoomName");
            return;
        }

        // Max Player 확인
        if (string.IsNullOrEmpty(Get<InputField>("MaxPlayerInputField").text))
        {
            Debug.LogWarning("Please Input Max Player");
            return;
        }

        // 값 읽어오기
        string roomName = Get<InputField>("RoomNameInputField").text;
        int maxPlayerCount = int.Parse(Get<InputField>("MaxPlayerInputField").text);
        maxPlayerCount = Mathf.Clamp(maxPlayerCount, 1, MAX_PLAYER);

        RoomOptions option = new RoomOptions();
        // 최대 플레이어 수 설정
        option.MaxPlayers = maxPlayerCount;

        // 방 생성 요청
        PhotonNetwork.CreateRoom(roomName, option);
    }

    public void Cancel(PointerEventData eventData)
    {
        gameObject.SetActive(false);
    }
}
