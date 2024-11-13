using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyScene : MonoBehaviourPunCallbacks
{
    public enum Panel { LobbyPanel, RoomPanel }

    [SerializeField] UI_MenuPanel menuPanel;
    [SerializeField] UI_RoomListPanel roomListPanel;

    void Start()
    {
        // �κ� ���� �õ�
        PhotonNetwork.JoinLobby();
    }

    // �κ� ���� ��
    public override void OnJoinedLobby()
    {
        Debug.Log("�κ� ���� ����");
    }

    // �κ� ���� ��
    public override void OnLeftLobby()
    {
        Debug.Log("�κ񿡼� ����");
        roomListPanel.ClearRoomEntries();
        PhotonNetwork.Disconnect();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log($"LobbyScene ���� ���� : {cause}");
        SceneManager.LoadScene("LoginScene");
    }

    // �κ� �ִ� ���� ��鿡 ���� ������ ����
    // ���� 1�� ��ü �濡 ���� ������ �޾ƿ���
    // ���Ŀ��� ��������� �ִ� ���� �������� �޾ƿ´�.
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        roomListPanel.UpdateRoomList(roomList);
    }

    // �� ���� ��
    public override void OnCreatedRoom()
    {
        Debug.Log($"�� ���� ���� : {PhotonNetwork.CurrentRoom.Name}");
    }

    // �濡 �� ���
    public override void OnJoinedRoom()
    {
        Debug.Log($"�� ���� ���� : {PhotonNetwork.CurrentRoom.Name}");
    }

    public void SetActivePanel(Panel panel)
    {
        menuPanel.gameObject.SetActive(panel == Panel.LobbyPanel);
        roomListPanel.gameObject.SetActive(panel == Panel.LobbyPanel);
    }
}
