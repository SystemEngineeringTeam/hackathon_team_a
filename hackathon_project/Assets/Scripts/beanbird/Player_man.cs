using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_man : MonoBehaviour
{
    private Animator anim = null;
    private Rigidbody2D rb = null;
    private Rigidbody2D krb = null;
    private float yvct = 10.0f;
    private float xvct = 10.0f;
    private int rl = 0;// 右が０左が１   

    public float speed;
    public GameObject l_knife;
    public GameObject r_knife;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
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
        throwknife();
    }

    public void throwknife(){
        Vector3 tmp = GameObject.Find("man").transform.position;

        if (Input.GetKeyDown(KeyCode.X))
        {
            if(rl == 0)//manが右を向いているとき
            {   
                GameObject rknife = Instantiate(r_knife, tmp, Quaternion.identity);
                krb = rknife.GetComponent<Rigidbody2D>();
                xvct = 10.0f;
            }else{// manが左を向いているとき
                GameObject lknife = Instantiate(l_knife, tmp, Quaternion.identity);
                xvct = -10.0f;
                krb = lknife.GetComponent<Rigidbody2D>();
            }

            krb.velocity = new Vector2(xvct, yvct);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        // ハートがプレイヤーに当たると消滅
        if(collision.tag == "heart"){
            Destroy(gameObject);
        }
    }


}
