using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using Photon.Pun;
using Photon.Realtime;


public class SettingName : MonoBehaviour
{
    public GameObject NameInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeNickName(){
        string nickName = NameInput.transform.Find("InputField").GetComponent<InputField>().text;
        if (!nickName.Equals("")){
                PhotonNetwork.LocalPlayer.NickName = nickName;
                PhotonNetwork.Disconnect();
                PhotonNetwork.ConnectUsingSettings();
        }
        else{
                Debug.LogError("Player Name is invalid.");
        }
        NameInput.SetActive(false);
    }

    public void showHideInput(){
        NameInput.SetActive(NameInput.activeSelf^true);
    }

}
