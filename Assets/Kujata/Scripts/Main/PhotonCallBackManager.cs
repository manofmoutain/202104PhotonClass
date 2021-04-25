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
    }

}
