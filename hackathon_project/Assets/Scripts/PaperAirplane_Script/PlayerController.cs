using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    int kaiten = 0;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(kaiten == 0){
            this.rigidbody2d.velocity = new Vector3(0,-8f,0);
        }else{
            this.rigidbody2d.velocity = new Vector3(kaiten/15f,-3f,0);
        }
        if(Input.GetKeyDown(KeyCode.RightArrow) && kaiten < 70){
            kaiten += 25;
            transform.Rotate(0,0,20);
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow ) && kaiten > -70){
            kaiten -= 25;
            transform.Rotate(0,0,-20);
        }
        if(transform.position.y < -140){
            Debug.Log("Goal!!!!!!!!!!!");
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        Debug.Log("aaa");
    }
}
