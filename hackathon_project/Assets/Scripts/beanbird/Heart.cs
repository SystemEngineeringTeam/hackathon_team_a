using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    GameObject ScoreMng;
    ScoreMng script;
    void Start()
    {   
        ScoreMng = GameObject.Find("ScoreMng");
        script = ScoreMng.GetComponent<ScoreMng>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        // ハートがブロックに当たると消滅
        if(collision.tag == "block"){
            Destroy(gameObject);
        }else if(collision.tag == "knife"){
            script.GetScore();
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()// 画面外にいくと消滅
    {
        Destroy(gameObject);    
    }


}