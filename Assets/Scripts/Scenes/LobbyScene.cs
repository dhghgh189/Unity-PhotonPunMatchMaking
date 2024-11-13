using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyScene : MonoBehaviourPunCallbacks
{
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
        PhotonNetwork.Disconnect();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log($"LobbyScene ���� ���� : {cause}");
        SceneManager.LoadScene("LoginScene");
    }
}
