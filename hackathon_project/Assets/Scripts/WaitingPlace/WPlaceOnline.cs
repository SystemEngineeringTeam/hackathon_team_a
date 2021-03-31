using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class WPlaceOnline : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public GameObject PlayerPrehub;
    public GameObject MainCam;
    void Start()
    {
        Screen.orientation = ScreenOrientation.AutoRotation;
        if(!PhotonNetwork.IsConnected){
            PhotonNetwork.LocalPlayer.NickName = PlayerPrefs.GetString("UserNickName");
            PhotonNetwork.ConnectUsingSettings();
        }else{
            setupPlayer();
        }
    }
    void OnGUI()
    {
        //ログインの状態を画面上に出力
        // GUILayout.Label(PhotonNetwork.NetworkClientState.ToString());
    }
     //ルームに入室前に呼び出される
    public override void OnConnectedToMaster() {
        Debug.Log("connected");
        // "room"という名前のルームに参加する（ルームが無ければ作成してから参加する）
        PhotonNetwork.JoinOrCreateRoom("hoge", new RoomOptions(), TypedLobby.Default);
    }

    
    //ルームに入室後に呼び出される
    public override void OnJoinedRoom(){
        setupPlayer();

        
    }
    void setupPlayer(){
        GameObject Player = PhotonNetwork.Instantiate(PlayerPrehub.name, new Vector3(0f,0f,0f), Quaternion.identity, 0);
        Player.GetComponent<Player>().enabled=true;
        Player.GetComponent<Player>().isMine=true;
        if(PhotonNetwork.LocalPlayer.NickName.CompareTo("")==0){
            Player.transform.GetChild(0).GetComponent<TextMesh>().text = "noName";
        }else{
            Player.transform.GetChild(0).GetComponent<TextMesh>().text = PhotonNetwork.LocalPlayer.NickName;
        }
        MainCam.GetComponent<FollowCamera>().playerObj =Player;
        
        SceneManager.LoadScene("SettingName",LoadSceneMode.Additive);
        SceneManager.LoadScene("Chat",LoadSceneMode.Additive);
    }
}
