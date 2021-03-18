using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;
public class GetUserList : MonoBehaviourPunCallbacks
{
    Photon.Realtime.Player[] players;
    // Start is called before the first frame update
    void Start()
    {
        if(!PhotonNetwork.IsConnected){
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    void Awake(){
        updatePlayerList();
    }
    // Update is called once per frame
    public virtual void OnPlayerEnteredRoom(Player newPlayer)
    {
    }
    void updatePlayerList(){
        players = PhotonNetwork.PlayerList;
    }
    void Update()
    {
        
    }
}
