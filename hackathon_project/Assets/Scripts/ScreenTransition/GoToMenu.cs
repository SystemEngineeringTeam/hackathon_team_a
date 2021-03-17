using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Photon.Pun;
using Photon.Realtime;

public class GoToMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //ボタンを押した時の処理
    public void PushButton()
    {
        SceneManager.LoadScene("Scenes/Menu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
