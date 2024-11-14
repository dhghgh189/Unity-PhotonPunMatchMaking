using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_MenuPanel : UIBase
{
    [SerializeField] UI_CreateRoomPanel createRoomPanel;
    private void OnEnable()
    {
        // Create Room ��ư �̺�Ʈ �߰�
        AddUIEvent(Get("btnCreateRoom"), Enums.UIEvent.PointerClick, CreateRoom);
        // Quick Join ��ư �̺�Ʈ �߰�
        AddUIEvent(Get("btnQuickJoin"), Enums.UIEvent.PointerClick, QuickJoin);
        // Leave Lobby ��ư �̺�Ʈ �߰�
        AddUIEvent(Get("btnLeaveLobby"), Enums.UIEvent.PointerClick, LeaveLobby);

        // Create Room Panel ��Ȱ��ȭ
        createRoomPanel.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        // Create Room ��ư �̺�Ʈ ����
        RemoveUIEvent(Get("btnCreateRoom"), Enums.UIEvent.PointerClick, CreateRoom);
        // Quick Join ��ư �̺�Ʈ ����
        RemoveUIEvent(Get("btnQuickJoin"), Enums.UIEvent.PointerClick, QuickJoin);
        // Leave Lobby ��ư �̺�Ʈ ����
        RemoveUIEvent(Get("btnLeaveLobby"), Enums.UIEvent.PointerClick, LeaveLobby);
    }

    public void CreateRoom(PointerEventData eventData)
    {
        // Create Room Panel Ȱ��ȭ
        createRoomPanel.gameObject.SetActive(true);
    }

    public void QuickJoin(PointerEventData eventData)
    {
        // ���� ���� (���� ������ ���� ���� ��� ���� ����)
        RoomOptions option = new RoomOptions();
        option.MaxPlayers = Define.MAX_PLAYER;
        PhotonNetwork.JoinRandomOrCreateRoom(roomName: $"{PhotonNetwork.LocalPlayer.NickName}'s Room", roomOptions: option);
    }

    public void LeaveLobby(PointerEventData eventData)
    {
        // �κ� ������ ��û
        PhotonNetwork.LeaveLobby();
    }
}
