using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //ボタンを押した時の処理
    public void PushNaruse()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("Scenes/Game2");
    }
    public void PushTakeru()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("Scenes/Snake/Game3");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}