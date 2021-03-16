using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    int kaiten = 0;
    public int flag = 0;
    public GameObject _button;
    float time = 0;
    int LholdFlag = 0;
    int RholdFlag = 0;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(kaiten == 0 && flag == 0){
            this.rigidbody2d.velocity = new Vector3(0,-7f,0);
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
            SceneManager.LoadScene("GameClear");
        }
        if(flag == 0 && LholdFlag != 0 && kaiten > -70){
            time += Time.deltaTime;
            if(time < 0.15 && LholdFlag == 1){
                transform.Rotate(0,0,-20);
                kaiten -= 25;
                LholdFlag++;
            }else if(time > 0.15 && time < 0.3 && LholdFlag == 2){
                transform.Rotate(0,0,-20);
                kaiten -= 25;
                LholdFlag++;
            }else if(time < 0.45 && time > 0.3 && LholdFlag == 3){
                transform.Rotate(0,0,-20);
                kaiten -= 25;
                LholdFlag++;
            }else if(time < 0.6 && time > 0.45 && LholdFlag == 4){
                transform.Rotate(0,0,-20);
                kaiten -= 25;
                LholdFlag++;
            }else if(time < 0.75 && time > 0.6 && LholdFlag == 5){
                transform.Rotate(0,0,-20);
                kaiten -= 25;
                LholdFlag++;
            }else if(time > 0.75 && LholdFlag == 6){
                transform.Rotate(0,0,-20);
                kaiten -= 25;
                LholdFlag++;
            }
        }
        if(flag == 0 && RholdFlag != 0 && kaiten < 70){
            time += Time.deltaTime;
            if(time < 0.15 && RholdFlag == 1){
                transform.Rotate(0,0,20);
                kaiten += 25;
                RholdFlag++;
            }else if(time > 0.15 && time < 0.3 && RholdFlag == 2){
                transform.Rotate(0,0,20);
                kaiten += 25;
                RholdFlag++;
            }else if(time > 0.3 && time < 0.45 && RholdFlag == 3){
                transform.Rotate(0,0,20);
                kaiten += 25;
                RholdFlag++;
            }else if(time > 0.45 && time < 0.6 && RholdFlag == 4){
                transform.Rotate(0,0,20);
                kaiten += 25;
                RholdFlag++;
            }else if(time > 0.6 && time < 0.75 && RholdFlag == 5){
                transform.Rotate(0,0,20);
                kaiten += 25;
                RholdFlag++;
            }else if(time > 0.75 && RholdFlag == 6){
                transform.Rotate(0,0,20);
                kaiten += 25;
                RholdFlag++;
            }
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

    public void LHold(){
        LholdFlag = 1;
    }
    public void RHold(){
        RholdFlag = 1;
    }
    public void LHoldOut(){
        LholdFlag = 0;
        time = 0;
    }
    public void RHoldOut(){
        RholdFlag = 0;
        time = 0;
    }
}
