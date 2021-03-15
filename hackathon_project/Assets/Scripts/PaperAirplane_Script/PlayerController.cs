using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int kaiten = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(kaiten == 0){
            transform.Translate(0,-0.15f,0);
        }else{
            transform.Translate(0,-0.06f,0);
        }
        if(Input.GetKeyDown(KeyCode.RightArrow) && kaiten < 70){
            kaiten += 25;
            transform.Rotate(0,0,20);
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow ) && kaiten > -70){
            kaiten -= 25;
            transform.Rotate(0,0,-20);
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        Debug.Log("aaa");
    }
}
