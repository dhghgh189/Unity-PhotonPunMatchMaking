using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Login : UIBase
{
    [SerializeField] float hideDelay;
    WaitForSeconds _delay;

    // 클라이언트 상태를 확인하기 위한 변수
    ClientState _state;

    private void Start()
    {
        // InfoPanel은 초기에 숨긴다.
        HideInfoPanel();

        // Login 버튼에 이벤트 추가
        AddUIEvent(Get("btnLogin"), Enums.UIEvent.PointerClick, Login);

        _delay = new WaitForSeconds(hideDelay);
        _state = PhotonNetwork.NetworkClientState;
    }

    private void Update()
    {
        // 상태 변화가 없으면 return
        if (_state == PhotonNetwork.NetworkClientState)
            return;

        // 변화한 상태를 저장
        _state = PhotonNetwork.NetworkClientState;

#if UNITY_EDITOR
        Debug.Log($"state : {_state}");
#endif

        switch (_state)
        {
            // 로그인 시도 실패
            case ClientState.Disconnected:
                ShowInfoPanel("Login Failed...", Color.red, false);
                StartCoroutine(HideRoutine());
                break;
        }
    }

    public void Login(PointerEventData eventData)
    {
        // 입력값을 받아온다.
        string name = Get<InputField>("idInputField").text;

        // 유효한지 검사
        if (string.IsNullOrEmpty(name))
        {
            Debug.LogWarning("Please Check ID!");
            return;
        }

        ShowInfoPanel("Please Wait...", Color.black);

        // 닉네임 설정 후 연결시도
        PhotonNetwork.NickName = name;
        PhotonNetwork.ConnectUsingSettings();
    }

    public void ShowInfoPanel(string msg, Color color, bool bShow = true)
    {
        Get<Text>("txtMessage").text = msg;
        Get<Text>("txtMessage").color = color;

        if (bShow)
            Get("InfoPanel").SetActive(true);
    }

    public void HideInfoPanel()
    {
        Get("InfoPanel").SetActive(false);
    }

    IEnumerator HideRoutine()
    {
        yield return _delay;
        HideInfoPanel();
    }
}
