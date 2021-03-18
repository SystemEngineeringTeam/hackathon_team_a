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
        InputField input =NameInput.transform.Find("InputField").GetComponent<InputField>();
        string nickName = input.text;
        if (!nickName.Equals("")){
                PhotonNetwork.LocalPlayer.NickName = nickName;
                PhotonNetwork.Disconnect();
                PhotonNetwork.ConnectUsingSettings();
                input.text="";
        }
        else{
                // Debug.LogError("Player Name is invalid.");
        }
        NameInput.SetActive(false);
    }
    public void ChangeNickNameInReturn(){
        if(Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter)){
            ChangeNickName();
        }
    }

    public void showHideInput(){
        NameInput.SetActive(NameInput.activeSelf^true);
    }

}
