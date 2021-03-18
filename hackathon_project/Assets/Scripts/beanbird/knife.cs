using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knife : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        // knifeがheartに当たると消滅
        if(collision.tag == "heart"){
            Destroy(gameObject);
        }
    }
    void OnBecameInvisible()// 画面外にいくと消滅
    {
        Destroy(gameObject);    
    }
}
