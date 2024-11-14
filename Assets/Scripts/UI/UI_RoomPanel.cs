using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UI_RoomPanel : UIBase
{
    private void OnEnable()
    {
        // Leave Room 버튼 이벤트 추가
        AddUIEvent(Get("btnLeaveRoom"), Enums.UIEvent.PointerClick, LeaveRoom);

        // 최초 1회 방 정보 설정
        SetRoomInfo();
    }

    private void OnDisable()
    {
        // Leave Room 버튼 이벤트 제거
        RemoveUIEvent(Get("btnLeaveRoom"), Enums.UIEvent.PointerClick, LeaveRoom);
    }

    public void LeaveRoom(PointerEventData eventData)
    {
        // 방 나가기 요청
        PhotonNetwork.LeaveRoom();
    }

    public void SetRoomInfo()
    {
        Get<Text>("txtRoomName").text = PhotonNetwork.CurrentRoom.Name;
    }
}
