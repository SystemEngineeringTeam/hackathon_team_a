using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHome(){
        SceneManager.LoadScene("WaitingPlace");
    }
    public void OnRetry(){
        SceneManager.LoadScene("SnakeMenu");
    }
    public void OnPlay(){
        SceneManager.LoadScene("Game3");
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