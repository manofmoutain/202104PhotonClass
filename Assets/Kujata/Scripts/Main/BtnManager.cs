using System;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

namespace Kujata.Scripts.Main
{
    public class BtnManager : MonoBehaviour
    {
        [SerializeField] private GameObject startGO;
        [SerializeField] private InputField inputName;
        [SerializeField] private Button loginBtn;

        public GameObject masterGO;
        [SerializeField] private Button enterLobby;
        // [SerializeField]private InputField lobbyNameInput;

        
        
        public GameObject lobbyGO;
        
        [SerializeField] private InputField roomNameInput;
        public string RoomName => roomNameInput.text;
        public GameObject roomGO;
        [SerializeField] private Button createRoomBtn;
        [SerializeField] private Button leaveRoomBtn;
        [SerializeField] private Button getCustomRoomListBtn;
        [SerializeField] private Button joinRandomRoomBtn;
        // [SerializeField] private InputField joinRoomNameInput;
        [SerializeField] private Button joinRoomBtn;
        [SerializeField] private Button joinOrCreateRoomBtn;
        [SerializeField] private Button leaveLobbyBtn;
        [SerializeField] private Button refreshFriendListBtn;
        


        private void Start()
        {
            startGO.SetActive(true);
            masterGO.SetActive(false);
            lobbyGO.SetActive(false);
            roomGO.SetActive(false);
            loginBtn.onClick.AddListener(delegate
            {
                startGO.SetActive(false);
                masterGO.SetActive(true);
                ConnectToPhotonSetting(inputName.text);
            });
            
            enterLobby.onClick.AddListener(delegate
            {
                masterGO.SetActive(false);
                lobbyGO.SetActive(true);
                EenterLobby();
            });
            
            leaveLobbyBtn.onClick.AddListener(delegate
            {
                lobbyGO.SetActive(false);
                masterGO.SetActive(true);
                LeaveLobby();
            });
            
            getCustomRoomListBtn.onClick.AddListener(delegate
            {
                GetCustomRoomList();
            });
            
            createRoomBtn.onClick.AddListener(delegate
            {
                RoomOptions roomOptions = new RoomOptions();
                roomOptions.MaxPlayers = 4;
                roomOptions.CustomRoomProperties = new ExitGames.Client.Photon.Hashtable(){{ "C0","Hello"}};
                roomOptions.CustomRoomPropertiesForLobby = new string[] {"C0"};
                TypedLobby typedLobby = new TypedLobby(roomNameInput.text , LobbyType.SqlLobby);
                CreateRoom(roomNameInput.text , roomOptions , typedLobby );
            });
            
            joinRoomBtn.onClick.AddListener(delegate
            {
                JoinRoom(roomNameInput.text);
            });
            
            joinRandomRoomBtn.onClick.AddListener(delegate
            {
                JoinRandomRoon();
            });
            
            joinOrCreateRoomBtn.onClick.AddListener(delegate
            {
                JoinOrCreateRoom(roomNameInput.text );
            });
            
            refreshFriendListBtn.onClick.AddListener(delegate
            {
                RefreshFriendList();
            });
            
        }

        private void RefreshFriendList()
        {
            string[] friendsList = new string[] {"A","B","C" };
            PhotonNetwork.FindFriends(friendsList);
        }

        private void JoinOrCreateRoom(string roomName)
        {
            lobbyGO.SetActive(false);


            RoomOptions roomOption = new RoomOptions();
            roomOption.MaxPlayers = 2;
            roomOption.CustomRoomProperties = new ExitGames.Client.Photon.Hashtable() { {"C0" , "Hello"}};
            roomOption.CustomRoomPropertiesForLobby = new string[] {"C0"};


            TypedLobby typedLobby = new TypedLobby("XD", LobbyType.SqlLobby);
            PhotonNetwork.JoinOrCreateRoom(roomName , roomOption , typedLobby);
        }

        private void JoinRandomRoon()
        {
            lobbyGO.SetActive(false);
            PhotonNetwork.JoinRandomRoom();
        }

        private void JoinRoom(string roomName)
        {
            lobbyGO.SetActive(false);
            PhotonNetwork.JoinRoom(roomName);
        }

        private void CreateRoom(string roomName, RoomOptions roomOption, TypedLobby typedLobby)
        {
            lobbyGO.SetActive(false);
            PhotonNetwork.CreateRoom(roomName , roomOption , typedLobby);
        }

        private void EenterLobby()
        {
            PhotonNetwork.JoinLobby();
        }

        private void ConnectToPhotonSetting(string userId)
        {
            PhotonNetwork.AuthValues = new AuthenticationValues();
            PhotonNetwork.AuthValues.UserId = userId;
            Debug.Log($"使用者；{userId}");
            PhotonNetwork.ConnectUsingSettings();
        }

        void LeaveLobby()
        {
            PhotonNetwork.LeaveLobby();
        }

        void GetCustomRoomList()
        {
            TypedLobby typedLobby = new TypedLobby("XD" , LobbyType.SqlLobby);
            PhotonNetwork.GetCustomRoomList(typedLobby , "C0='hello'");
        }
    }
}