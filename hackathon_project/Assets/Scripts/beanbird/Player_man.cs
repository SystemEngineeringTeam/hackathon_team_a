using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_man : MonoBehaviour
{
    private Animator anim = null;
    private Rigidbody2D rb = null;
    private Rigidbody2D krb = null;
    private float yvct = 15.0f;
    private float xvct = 15.0f;
    private int rl = 0;// 右が０左が１   
    private int judge = 0;

    public float speed;
    public GameObject l_knife;
    public GameObject r_knife;
    public GameObject Sound;
    SoundMng soundscript;

    Vector2 startPos;
    Vector2 startPoint;

    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        soundscript = Sound.GetComponent<SoundMng>();
        var renderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {   
        pcmove();
        phonemove();
    }

    public void pcmove(){
        float horizontalKey = Input.GetAxis("Horizontal"); 
        float xSpeed = 0.0f;

        if (horizontalKey > 0) // 右移動
        {
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("run", true);
            xSpeed = speed;
            rl = 0;
        }
        else if (horizontalKey < 0) // 左移動
        {
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetBool("run", true);
            xSpeed = -speed;
            rl = 1;
        }
        else// 止まってる
        {
            anim.SetBool("run", false);
            xSpeed = 0.0f;
        }
        rb.velocity = new Vector2(xSpeed, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.X)){
            throwknife();
        }
    }

    public void phonemove(){
        Vector2 direction = new Vector2(0, 0);
        
        if (Input.touchCount > 0)// タッチ数
        {
            Touch touch = Input.GetTouch(0);// touch構造体の取得
            float xspeed = 0;
            // スワイプの移動距離
 
            switch (touch.phase)
            {
                
                case TouchPhase.Began:
                    startPoint = touch.position;
                    Debug.Log(startPoint);
                    break;

                case TouchPhase.Moved:
                    direction = touch.position - startPoint;
                    if(startPoint.x>0){
                        if (direction.x > 0) // 右移動
                        {
                            transform.localScale = new Vector3(1, 1, 1);
                            anim.SetBool("run", true);
                            xspeed = speed;
                            rl = 0;
                        }
                        else if (direction.x < 0) // 左移動
                        {
                            transform.localScale = new Vector3(-1, 1, 1);
                            anim.SetBool("run", true);
                            xspeed = -speed;
                            rl = 1;
                        }
                        else// 止まってる
                        {
                            xspeed = 0.0f;
                        }
                        rb.velocity = new Vector2(xspeed, rb.velocity.y);
                    }else{
                        throwknife();
                        judge = 1;
                    }
                    break;

                case TouchPhase.Ended:
                    anim.SetBool("run", false);
                    rb.velocity = new Vector2(0, 0);
                    judge = 0;
                    break;
            }

        }

    }

    public void throwknife(){
        Vector3 tmp = GameObject.Find("man").transform.position;
        if(judge == 0){
            if(rl == 0)//manが右を向いているとき
            {   
                GameObject rknife = Instantiate(r_knife, tmp, Quaternion.identity);
                krb = rknife.GetComponent<Rigidbody2D>();
                xvct = 15.0f;
            }else{// manが左を向いているとき
                GameObject lknife = Instantiate(l_knife, tmp, Quaternion.identity);
                xvct = -15.0f;
                krb = lknife.GetComponent<Rigidbody2D>();
            }

            krb.velocity = new Vector2(xvct, yvct);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        // ハートがプレイヤーに当たると消滅
        if(collision.tag == "heart"){
            soundscript.pityun();
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()// 画面外にいくと消滅
    {
        soundscript.pityun();
        Destroy(gameObject);
    }
}