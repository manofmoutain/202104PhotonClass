using System;
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

        [SerializeField] private GameObject masterGO;
        [SerializeField] private Button enterLobby;
        public GameObject lobbyGO;

        private void Start()
        {
            startGO.SetActive(true);
            masterGO.SetActive(false);
            lobbyGO.SetActive(false);
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
        }

        private void EenterLobby()
        {
            PhotonNetwork.JoinLobby();
        }

        private void ConnectToPhotonSetting(string userId)
        {
            PhotonNetwork.NickName=userId;
            PhotonNetwork.ConnectUsingSettings();
        }
    }
}