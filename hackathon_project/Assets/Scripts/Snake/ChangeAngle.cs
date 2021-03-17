using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeAngle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = Quaternion.Euler(0,0,GetVector.GetAng());
    }

    void OnTriggerEnter2D(Collider2D other){
        SceneManager.LoadScene("SnakeGameOver");
    }
}
