using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Tim;

namespace Kujata.Scripts.Main
{
    public class PhotonCallBackManager : MyPhotonRealtimeCallBack
    {
        [SerializeField] private BtnManager _btnManager;
        
        public override void OnConnected()
        {
            base.OnConnected();
        }

        public override void OnConnectedToMaster()
        {
            base.OnConnectedToMaster();
        }

        public override void OnJoinedLobby()
        {
            base.OnJoinedLobby();
            _btnManager.lobbyGO.SetActive(true);
        }

        public override void OnLeftLobby()
        {
            base.OnLeftLobby();
            _btnManager.masterGO.SetActive(true);
        }

        public override void OnJoinedRoom()
        {
            base.OnJoinedRoom();
            print($"已加入{_btnManager.RoomName}");
            _btnManager.roomGO.SetActive(true);
        }

        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            base.OnCreateRoomFailed(returnCode, message);
            _btnManager.lobbyGO.SetActive(true);
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            base.OnJoinRandomFailed(returnCode, message);
            _btnManager.lobbyGO.SetActive(true);
        }

        public override void OnJoinRoomFailed(short returnCode, string message)
        {
            base.OnJoinRoomFailed(returnCode, message);
            _btnManager.lobbyGO.SetActive(true);
        }
    }

}
