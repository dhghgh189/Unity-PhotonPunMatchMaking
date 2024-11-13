using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginScene : MonoBehaviourPunCallbacks
{
    // 서버에 연결 성공한 경우
    public override void OnConnectedToMaster()
    {
        // 로비 씬으로 단순 이동
        SceneManager.LoadScene("LobbyScene");
    }

    // 접속 끊긴 경우
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Disconnected");
    }
}
