using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeMove : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject sound;
    void Start()
    {
        sound = GameObject.Find("MainSoundObject");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHome(){
        SceneManager.LoadScene("WaitingPlace");
        gameObject.SetActive(false);
    }
    public void OnRetry(){
        SceneManager.LoadScene("SnakeMenu");
    }
    public void OnPlay(){
        SceneManager.LoadScene("Game3");
        sound.SetActive(false);
    }
    public void OnInfo(){
        SceneManager.LoadScene("SnakeInfo");
    }
    public void OnInfoNext(){
        SceneManager.LoadScene("SnakeInfo2");
    }
    public void OnInfoEnd(){
        SceneManager.LoadScene("SnakeMenu");
    }
}