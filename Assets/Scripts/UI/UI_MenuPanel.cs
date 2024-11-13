using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_MenuPanel : UIBase
{
    private void OnEnable()
    {
        // Create Room ��ư �̺�Ʈ �߰�
        AddUIEvent(Get("btnCreateRoom"), Enums.UIEvent.PointerClick, CreateRoom);
        // Leave Lobby ��ư �̺�Ʈ �߰�
        AddUIEvent(Get("btnLeaveLobby"), Enums.UIEvent.PointerClick, LeaveLobby);

        // Create Room Panel ��Ȱ��ȭ
        Get("CreateRoomPanel").gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        // Create Room ��ư �̺�Ʈ ����
        RemoveUIEvent(Get("btnCreateRoom"), Enums.UIEvent.PointerClick, CreateRoom);
        // Leave Lobby ��ư �̺�Ʈ ����
        RemoveUIEvent(Get("btnLeaveLobby"), Enums.UIEvent.PointerClick, LeaveLobby);
    }

    public void CreateRoom(PointerEventData eventData)
    {
        // Create Room Panel Ȱ��ȭ
        Get("CreateRoomPanel").gameObject.SetActive(true);
    }

    public void LeaveLobby(PointerEventData eventData)
    {
        // �κ� ������ ��û
        PhotonNetwork.LeaveLobby();
    }
}
