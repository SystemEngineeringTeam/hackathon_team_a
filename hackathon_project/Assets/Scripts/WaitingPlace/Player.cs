using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody2D _rigidbody;
    float x_speed = 0;
    float y_speed = 0;
    Vector2 startPos;

    void Start()
    {
        
    }

    void Update()
    {
        //　メソッドの呼び出し
        MoveSwipe();
    }

    void MoveSwipe() //スワイプで移動
    {
        if (Input.GetMouseButtonDown(0))
        {
            // マウスをクリックした座標を取得
            this.startPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // マウスを離した座標を取得
            Vector2 endPos = Input.mousePosition;

            float x_swipeLength = endPos.x - this.startPos.x;
            float y_swipeLength = endPos.y - this.startPos.y;

            // スワイプの長さを速度に変換する
            this.x_speed = x_swipeLength / 600.0f;
            this.y_speed = y_swipeLength / 600.0f;
        }

        //　オブジェクトの移動
        transform.Translate(this.x_speed, this.y_speed, 0);

        //　オブジェクトの減速
        this.x_speed *= 0.98f;
        this.y_speed *= 0.98f;
    }
}
