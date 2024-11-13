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
        // 로비 입장 시도
        PhotonNetwork.JoinLobby();
    }

    // 로비 입장 시
    public override void OnJoinedLobby()
    {
        Debug.Log("로비 입장 성공");
    }

    // 로비 퇴장 시
    public override void OnLeftLobby()
    {
        Debug.Log("로비에서 퇴장");
        roomListPanel.ClearRoomEntries();
        PhotonNetwork.Disconnect();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log($"LobbyScene 접속 해제 : {cause}");
        SceneManager.LoadScene("LoginScene");
    }

    // 로비에 있는 동안 방들에 대한 정보를 수신
    // 최초 1번 전체 방에 대한 정보를 받아오며
    // 이후에는 변경사항이 있는 방의 정보만을 받아온다.
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        roomListPanel.UpdateRoomList(roomList);
    }

    // 방 생성 시
    public override void OnCreatedRoom()
    {
        Debug.Log($"방 생성 성공 : {PhotonNetwork.CurrentRoom.Name}");
    }

    // 방에 들어간 경우
    public override void OnJoinedRoom()
    {
        Debug.Log($"방 입장 성공 : {PhotonNetwork.CurrentRoom.Name}");
    }

    public void SetActivePanel(Panel panel)
    {
        menuPanel.gameObject.SetActive(panel == Panel.LobbyPanel);
        roomListPanel.gameObject.SetActive(panel == Panel.LobbyPanel);
    }
}
