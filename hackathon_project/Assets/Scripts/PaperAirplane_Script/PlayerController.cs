using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    int kaiten = 0;
    public int flag = 0;
    public GameObject _button;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(kaiten == 0 && flag == 0){
            this.rigidbody2d.velocity = new Vector3(0,-8f,0);
        }else if(flag == 0){
            this.rigidbody2d.velocity = new Vector3(kaiten/15f,-3f,0);
        }
        if(Input.GetKeyDown(KeyCode.RightArrow) && kaiten < 70 && flag == 0){
            kaiten += 25;
            transform.Rotate(0,0,20);
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow ) && kaiten > -70 && flag == 0){
            kaiten -= 25;
            transform.Rotate(0,0,-20);
        }
        if(transform.position.y < -138.8f){
            kaiten = 0;
            flag = 1;
            this.rigidbody2d.velocity = Vector3.zero;
            transform.rotation = Quaternion.identity;
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        kaiten = 0;
        flag = 1;
        this.rigidbody2d.velocity = Vector3.zero;
        transform.rotation = Quaternion.identity;
        _button = GameObject.Find("Director");
        _button.GetComponent<ButtonController>().buttonactiv();
    }
}
