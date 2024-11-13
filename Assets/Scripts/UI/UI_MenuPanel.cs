using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_MenuPanel : UIBase
{
    private void OnEnable()
    {
        // Create Room 버튼 이벤트 추가
        AddUIEvent(Get("btnCreateRoom"), Enums.UIEvent.PointerClick, CreateRoom);
        // Leave Lobby 버튼 이벤트 추가
        AddUIEvent(Get("btnLeaveLobby"), Enums.UIEvent.PointerClick, LeaveLobby);

        // Create Room Panel 비활성화
        Get("CreateRoomPanel").gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        // Create Room 버튼 이벤트 제거
        RemoveUIEvent(Get("btnCreateRoom"), Enums.UIEvent.PointerClick, CreateRoom);
        // Leave Lobby 버튼 이벤트 제거
        RemoveUIEvent(Get("btnLeaveLobby"), Enums.UIEvent.PointerClick, LeaveLobby);
    }

    public void CreateRoom(PointerEventData eventData)
    {
        // Create Room Panel 활성화
        Get("CreateRoomPanel").gameObject.SetActive(true);
    }

    public void LeaveLobby(PointerEventData eventData)
    {
        // 로비 나가기 요청
        PhotonNetwork.LeaveLobby();
    }
}
