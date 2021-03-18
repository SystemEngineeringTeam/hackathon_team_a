using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToWaitingPlace : MonoBehaviour
{
    GameObject sound;
    // Start is called before the first frame update
    void Start()
    {
        sound = GameObject.Find("EventSystem");
    }

    //ボタンを押した時の処理
    public void PushButton()
    {
        sound.SetActive(false);
        SceneManager.LoadScene("Scenes/WaitingPlace");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
