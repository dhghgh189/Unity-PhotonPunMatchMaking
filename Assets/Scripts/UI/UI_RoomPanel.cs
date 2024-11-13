using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class UI_RoomPanel : UIBase
{
    private void OnEnable()
    {
        // Leave Room ��ư �̺�Ʈ �߰�
        AddUIEvent(Get("btnLeaveRoom"), Enums.UIEvent.PointerClick, LeaveRoom);
    }

    private void OnDisable()
    {
        // Leave Room ��ư �̺�Ʈ ����
        RemoveUIEvent(Get("btnLeaveRoom"), Enums.UIEvent.PointerClick, LeaveRoom);
    }

    public void LeaveRoom(PointerEventData eventData)
    {
        // �� ������ ��û
        PhotonNetwork.LeaveRoom();
    }
}
