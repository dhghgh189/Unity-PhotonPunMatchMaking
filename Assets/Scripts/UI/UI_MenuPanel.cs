using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_MenuPanel : UIBase
{
    private void OnEnable()
    {
        // Leave Lobby 버튼 이벤트 추가
        AddUIEvent(Get("btnLeaveLobby"), Enums.UIEvent.PointerClick, LeaveLobby);
    }

    public void LeaveLobby(PointerEventData eventData)
    {
        // 로비 나가기 요청
        PhotonNetwork.LeaveLobby();
    }
}
