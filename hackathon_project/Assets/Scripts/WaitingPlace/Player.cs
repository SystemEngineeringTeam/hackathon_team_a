﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 移動スピード
    public float speed = 10;
    float x_speed = 0;
    float y_speed = 0;
    Vector2 startPos;

    public AudioClip sound1;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //　メソッドの呼び出し
        //Move();// スマホ用
        MoveSwipe();// PC用

    }

    /*void Move() //スワイプで移動
    {   
        
        Vector2 direction = new Vector2(0, 0);
 
        if (Input.touchCount > 0)// タッチ数
        {
            Touch touch = Input.GetTouch(0);// touch構造体の取得
            // スワイプの移動距離
            float x = touch.deltaPosition.x;
            float y = touch.deltaPosition.y;
 
            //　移動する向きを求める
            direction = new Vector2(x, y).normalized;
        }
 
        // 移動する向きとスピード
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }*/

    void MoveSwipe()
    {   
        Vector2 dire = new Vector2(0, 0);
        // マウスが左クリックされたとき
        if (Input.GetMouseButtonDown(0))
        {
            // マウスをクリックした座標
            this.startPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // マウスを離した座標
            Vector2 endPos = Input.mousePosition;

            float x_swipeLength = endPos.x - this.startPos.x;
            float y_swipeLength = endPos.y - this.startPos.y;

            // スワイプの長さを速度に変換する
            this.x_speed = x_swipeLength / 10.0f;
            this.y_speed = y_swipeLength / 10.0f;
        }

        dire = new Vector2(this.x_speed, this.y_speed);
        GetComponent<Rigidbody2D>().velocity = dire;

        this.x_speed *= 0.99f;
        this.y_speed *= 0.99f;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "tea"){
            audioSource.PlayOneShot(sound1);
        }
    }
}
