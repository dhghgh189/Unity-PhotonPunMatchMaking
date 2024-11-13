using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginScene : MonoBehaviourPunCallbacks
{
    // ������ ���� ������ ���
    public override void OnConnectedToMaster()
    {
        // �κ� ������ �ܼ� �̵�
        SceneManager.LoadScene("LobbyScene");
    }

    // ���� ���� ���
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Disconnected");
    }
}
