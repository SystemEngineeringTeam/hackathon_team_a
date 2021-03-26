using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Photon.Pun;
using Photon.Realtime;

public class PopupToMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public void CloseScene(){
        player.GetComponent<Player>().enabled=true;
        StartCoroutine(_closescene());
    }
    IEnumerator _closescene(){
        yield return SceneManager.UnloadSceneAsync("popUpInWPlace");
    }

    public void Change2Menu(){
        PhotonNetwork.Destroy(player);
        // PhotonNetwork.Disconnect();
        SceneManager.LoadScene("Menu");
    }
}
