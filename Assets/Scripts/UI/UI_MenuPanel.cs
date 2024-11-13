using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_MenuPanel : UIBase
{
    private void OnEnable()
    {
        // Leave Lobby ��ư �̺�Ʈ �߰�
        AddUIEvent(Get("btnLeaveLobby"), Enums.UIEvent.PointerClick, LeaveLobby);
    }

    public void LeaveLobby(PointerEventData eventData)
    {
        // �κ� ������ ��û
        PhotonNetwork.LeaveLobby();
    }
}
